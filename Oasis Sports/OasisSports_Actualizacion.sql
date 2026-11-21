USE [OasisSports];
GO

IF OBJECT_ID('dbo.usuarios_C', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.usuarios_C (
        IdVersion INT IDENTITY(1,1) PRIMARY KEY,
        id_usuario INT NOT NULL,
        nomUsuario NVARCHAR(100) NULL,
        contraseña VARCHAR(100) NULL,
        bloqueado BIT NOT NULL,
        eliminado BIT NOT NULL,
        Fecha DATE NOT NULL,
        Hora TIME(0) NOT NULL,
        Usuario NVARCHAR(100) NOT NULL,
        Activo BIT NOT NULL,
        CONSTRAINT FK_usuarios_C_usuarios FOREIGN KEY (id_usuario) REFERENCES dbo.usuarios (id_usuario)
    );
END
GO

INSERT INTO dbo.usuarios_C (id_usuario, nomUsuario, contraseña, bloqueado, eliminado, Fecha, Hora, Usuario, Activo)
SELECT u.id_usuario, u.nomUsuario, u.contraseña, u.bloqueado, u.eliminado,
       CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME(0)), 'sistema', 1
FROM dbo.usuarios u
WHERE NOT EXISTS (SELECT 1 FROM dbo.usuarios_C c WHERE c.id_usuario = u.id_usuario);
GO

CREATE OR ALTER TRIGGER dbo.usuario_actualizado
ON dbo.usuarios
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF TRIGGER_NESTLEVEL(OBJECT_ID('dbo.usuario_c_actualizado')) > 0
        RETURN;

    DECLARE @Usuario NVARCHAR(100) = CONVERT(NVARCHAR(100), SESSION_CONTEXT(N'usuario'));
    IF @Usuario IS NULL
        SET @Usuario = 'sistema';

    DECLARE @Cambiados TABLE (id_usuario INT);

    INSERT INTO @Cambiados (id_usuario)
    SELECT i.id_usuario
    FROM inserted i
    LEFT JOIN deleted d ON d.id_usuario = i.id_usuario
    WHERE d.id_usuario IS NULL
       OR EXISTS (SELECT i.nomUsuario, i.contraseña, i.bloqueado, i.eliminado
                  EXCEPT
                  SELECT d.nomUsuario, d.contraseña, d.bloqueado, d.eliminado);

    UPDATE dbo.usuarios_C
    SET Activo = 0
    WHERE Activo = 1 AND id_usuario IN (SELECT id_usuario FROM @Cambiados);

    INSERT INTO dbo.usuarios_C (id_usuario, nomUsuario, contraseña, bloqueado, eliminado, Fecha, Hora, Usuario, Activo)
    SELECT i.id_usuario, i.nomUsuario, i.contraseña, i.bloqueado, i.eliminado,
           CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME(0)), @Usuario, 1
    FROM inserted i
    WHERE i.id_usuario IN (SELECT id_usuario FROM @Cambiados);
END
GO

CREATE OR ALTER TRIGGER dbo.usuario_eliminado
ON dbo.usuarios
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.usuarios
    SET eliminado = 1
    WHERE id_usuario IN (SELECT id_usuario FROM deleted);
END
GO

CREATE OR ALTER TRIGGER dbo.usuario_c_actualizado
ON dbo.usuarios_C
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE u
    SET u.nomUsuario = i.nomUsuario,
        u.contraseña = i.contraseña,
        u.bloqueado = i.bloqueado,
        u.eliminado = i.eliminado
    FROM dbo.usuarios u
    INNER JOIN inserted i ON i.id_usuario = u.id_usuario
    INNER JOIN deleted d ON d.IdVersion = i.IdVersion
    WHERE i.Activo = 1 AND d.Activo = 0;
END
GO

IF NOT EXISTS (SELECT 1 FROM Permiso WHERE Codigo = 'VE006')
    INSERT INTO Permiso (Nombre, Codigo, EsGrupo) VALUES ('Reporte inteligente', 'VE006', 0);

DECLARE @IdPermiso INT;
DECLARE @IdGrupo INT;

SELECT @IdPermiso = Id FROM Permiso WHERE Codigo = 'VE006';
SELECT @IdGrupo = Id FROM Permiso WHERE Codigo = 'GE051';

IF @IdGrupo IS NOT NULL AND NOT EXISTS (SELECT 1 FROM PermisoRelacion WHERE PadreId = @IdGrupo AND HijoId = @IdPermiso)
    INSERT INTO PermisoRelacion (PadreId, HijoId) VALUES (@IdGrupo, @IdPermiso);
GO

DECLARE @IdEspanol INT;
DECLARE @IdIngles INT;

SELECT @IdEspanol = IdIdioma FROM Idioma WHERE Nombre = CONCAT('Espa', NCHAR(241), 'ol');
SELECT @IdIngles = IdIdioma FROM Idioma WHERE Nombre IN ('English', 'Ingles', CONCAT('Ingl', NCHAR(233), 's'));

DECLARE @Claves TABLE (Clave NVARCHAR(100), Espanol NVARCHAR(200), Ingles NVARCHAR(200));

INSERT INTO @Claves (Clave, Espanol, Ingles) VALUES
('mAESTROSToolStripMenuItem', 'MAESTROS', 'MASTERS'),
('lblTituloCambios', 'Bitacora de cambios', 'Change log'),
('lblUsuarioCambios', 'Usuario', 'User'),
('lblNombreCambios', 'Nombre', 'Name'),
('lblFechaInicioCambios', 'Fecha inicio', 'Start date'),
('lblFechaFinCambios', 'Fecha fin', 'End date'),
('btnAplicarCambios', 'Aplicar', 'Apply'),
('btnLimpiarCambios', 'Limpiar', 'Clear'),
('btnActivarCambios', 'Activar', 'Activate'),
('btnSalirCambios', 'Salir', 'Exit'),
('aYUDAToolStripMenuItem', 'AYUDA', 'HELP'),
('btnAyuda', '?', '?'),
('rEPORTEINTELIGENTEToolStripMenuItem', 'REPORTE INTELIGENTE', 'SMART REPORT'),
('lblTituloInteligente', 'Reporte inteligente', 'Smart report'),
('lblDesdeInteligente', 'Desde', 'From'),
('lblHastaInteligente', 'Hasta', 'To'),
('btnAnalizar', 'Analizar', 'Analyze'),
('lblIndicadores', 'Indicadores', 'Indicators'),
('lblConclusiones', 'Conclusiones y recomendaciones', 'Conclusions and recommendations'),
('btnExportarPDFInteligente', 'Exportar a PDF', 'Export to PDF'),
('btnVolverInteligente', 'Volver', 'Back');

IF @IdEspanol IS NOT NULL
    INSERT INTO Traduccion (IdIdioma, Clave, Texto)
    SELECT @IdEspanol, c.Clave, c.Espanol FROM @Claves c
    WHERE NOT EXISTS (SELECT 1 FROM Traduccion t WHERE t.IdIdioma = @IdEspanol AND t.Clave = c.Clave);

IF @IdIngles IS NOT NULL
    INSERT INTO Traduccion (IdIdioma, Clave, Texto)
    SELECT @IdIngles, c.Clave, c.Ingles FROM @Claves c
    WHERE NOT EXISTS (SELECT 1 FROM Traduccion t WHERE t.IdIdioma = @IdIngles AND t.Clave = c.Clave);
GO
