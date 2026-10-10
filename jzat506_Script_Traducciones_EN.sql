
USE [OasisSports]
GO

DECLARE @IdIngles INT;
SELECT @IdIngles = IdIdioma FROM Idioma WHERE Nombre IN ('English', 'Ingles', 'Inglés');

IF @IdIngles IS NULL
BEGIN
    INSERT INTO Idioma (Nombre) VALUES ('English');
    SET @IdIngles = SCOPE_IDENTITY();
END


DECLARE @ClaveMenuContrasenia NVARCHAR(100) = CONCAT('cAMBIARCONTRASE', NCHAR(209), 'AToolStripMenuItem');

DELETE FROM Traduccion WHERE IdIdioma = @IdIngles AND Clave IN (
    @ClaveMenuContrasenia,
    'lblTituloContrasenia', 'lblActual', 'lblNueva', 'lblRepetir', 'btnGuardarContrasenia', 'btnCancelarContrasenia',
    'btnQuitarProducto',
    'lblIdiomaActivo', 'lblClaves', 'lblClave', 'lblTexto', 'lblNuevoIdioma',
    'lblProductos', 'lblCantidad', 'btnAgregarProducto', 'lblCarrito', 'btnConfirmarProductos', 'btnCerrar',
    'lblDNI', 'lblNombre', 'lblApellido', 'lblEmail', 'lblTelefono', 'lblDireccion',
    'btnRegistrar', 'btnModificar', 'btnVolverCancelar',
    'lblTituloCobro', 'lblTotalTexto', 'lblMedioPago', 'radioEfectivo', 'radioTransferencia',
    'lblBanco', 'lblNumeroCuenta', 'lblTitular', 'btnCobrar', 'btnCancelarPago',
    'lblTituloFactura', 'lblDNIVenta', 'btnBuscarCliente', 'btnSeleccionarProductos',
    'btnCobrarVenta', 'btnGenerar', 'btnVolverVentas',
    'vENDEDORToolStripMenuItem', 'vENTASToolStripMenuItem', 'rEGISTRARCLIENTEToolStripMenuItem'
);

INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES
(@IdIngles, 'lblProductos', 'Products'),
(@IdIngles, 'lblCantidad', 'Quantity'),
(@IdIngles, 'btnAgregarProducto', 'Add'),
(@IdIngles, 'lblCarrito', 'Cart'),
(@IdIngles, 'btnConfirmarProductos', 'Confirm products'),
(@IdIngles, 'btnQuitarProducto', 'Remove'),
(@IdIngles, 'btnCerrar', 'Close');

INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES
(@IdIngles, 'lblDNI', 'ID number : '),
(@IdIngles, 'lblNombre', 'FIRST NAME : '),
(@IdIngles, 'lblApellido', 'LAST NAME : '),
(@IdIngles, 'lblEmail', 'EMAIL : '),
(@IdIngles, 'lblTelefono', 'PHONE : '),
(@IdIngles, 'lblDireccion', 'ADDRESS : '),
(@IdIngles, 'btnRegistrar', 'REGISTER'),
(@IdIngles, 'btnModificar', 'EDIT'),
(@IdIngles, 'btnVolverCancelar', 'BACK');

INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES
(@IdIngles, 'lblTituloCobro', 'Charge sale'),
(@IdIngles, 'lblTotalTexto', 'Total to charge:'),
(@IdIngles, 'lblMedioPago', 'Payment method'),
(@IdIngles, 'radioEfectivo', 'Cash'),
(@IdIngles, 'radioTransferencia', 'Bank transfer'),
(@IdIngles, 'lblBanco', 'Bank'),
(@IdIngles, 'lblNumeroCuenta', 'Account number'),
(@IdIngles, 'lblTitular', 'Account holder'),
(@IdIngles, 'btnCobrar', 'Charge'),
(@IdIngles, 'btnCancelarPago', 'Cancel');

INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES
(@IdIngles, 'lblTituloFactura', 'Generate invoice'),
(@IdIngles, 'lblDNIVenta', 'ID number'),
(@IdIngles, 'btnBuscarCliente', 'Search'),
(@IdIngles, 'btnSeleccionarProductos', 'Select products'),
(@IdIngles, 'btnCobrarVenta', 'Charge sale'),
(@IdIngles, 'btnGenerar', 'Generate invoice'),
(@IdIngles, 'btnVolverVentas', 'Back');

INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES
(@IdIngles, 'lblTituloContrasenia', 'Change password'),
(@IdIngles, 'lblActual', 'Current password'),
(@IdIngles, 'lblNueva', 'New password'),
(@IdIngles, 'lblRepetir', 'Repeat new password'),
(@IdIngles, 'btnGuardarContrasenia', 'SAVE'),
(@IdIngles, 'btnCancelarContrasenia', 'CANCEL');

INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES
(@IdIngles, 'lblIdiomaActivo', 'Language'),
(@IdIngles, 'lblClaves', 'Keys'),
(@IdIngles, 'lblClave', 'Key'),
(@IdIngles, 'lblTexto', 'Translation'),
(@IdIngles, 'lblNuevoIdioma', 'New language');

INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES
(@IdIngles, 'vENDEDORToolStripMenuItem', 'SELLER'),
(@IdIngles, 'vENTASToolStripMenuItem', 'SALES'),
(@IdIngles, 'rEGISTRARCLIENTEToolStripMenuItem', 'CUSTOMER MANAGEMENT'),
(@IdIngles, @ClaveMenuContrasenia, 'CHANGE PASSWORD');
GO
