# Facturama SDK for .NET 8

[![NuGet](https://img.shields.io/nuget/v/Facturama.Sdk.svg)](https://www.nuget.org/packages/Facturama.Sdk/)
[![Downloads](https://img.shields.io/nuget/dt/Facturama.Sdk.svg)](https://www.nuget.org/packages/Facturama.Sdk/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

SDK oficial para integración con la API de Facturama en .NET 8.

## 🚀 Instalación
```bash
dotnet add package Facturama.Sdk
```

## ⚙️ Configuración rápida

### appsettings.json
```json
{
  "Facturama": {
    "Username": "tu-usuario",
    "Password": "tu-password",
    "Environment": "Sandbox"
  }
}
```

### Program.cs
```csharp
builder.Services.AddFacturama(builder.Configuration);
```

## 💡 Uso Básico

### Crear CFDI
```csharp
public class InvoiceService
{
    private readonly IFacturamaClient _facturama;

    public InvoiceService(IFacturamaClient facturama)
    {
        _facturama = facturama;
    }

    public async Task CreateInvoice()
    {
        var cfdi = await _facturama.Cfdis.CreateAsync(new CfdiRequest
        {
            Receiver = new ReceiverRequest
            {
                Rfc = "XAXX010101000",
                Name = "Cliente de Prueba",
                CfdiUse = "G03"
            },
            Items = new List<CfdiItemRequest>
            {
                new CfdiItemRequest
                {
                    ProductCode = "84111506",
                    Description = "Servicio de consultoría",
                    UnitValue = 1000m,
                    Quantity = 1
                }
            }
        });
    }
}
```

## 📚 Documentación

- [Guía de Inicio](docs/getting-started.md)
- [Configuración Avanzada](docs/configuration.md)
- [Ejemplos](docs/examples.md)
- [API Reference](docs/api-reference.md)

Visita [https://github.com/tu-usuario/facturama-sdk-net8/wiki](https://github.com/tu-usuario/facturama-sdk-net8/wiki)

## 🤝 Contribuir

Las contribuciones son bienvenidas. Por favor:

1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

MIT License - ver [LICENSE](LICENSE)

## 📞 Soporte

- 📧 Email: soporte@tudominio.com
- 🐛 Issues: [GitHub Issues](https://github.com/tu-usuario/facturama-sdk-net8/issues)