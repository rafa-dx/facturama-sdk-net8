using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Mercancia
    {
        [JsonPropertyName("BienesTransp")]
        public string BienesTransp { get; init; }

        [JsonPropertyName("ClaveSTCC")]
        public string ClaveSTCC { get; init; }

        [JsonPropertyName("Descripcion")]
        public string Descripcion { get; init; }

        [JsonPropertyName("Cantidad")]
        public decimal Cantidad { get; init; }

        [JsonPropertyName("ClaveUnidad")]
        public string ClaveUnidad { get; init; }

        [JsonPropertyName("Unidad")]
        public string Unidad { get; init; }

        [JsonPropertyName("Dimensiones")]
        public string Dimensiones { get; init; }

        [JsonPropertyName("MaterialPeligroso")]
        public string MaterialPeligroso { get; init; }

        [JsonPropertyName("CveMaterialPeligroso")]
        public string CveMaterialPeligroso { get; init; }

        [JsonPropertyName("Embalaje")]
        public string Embalaje { get; init; }

        [JsonPropertyName("DescripEmbalaje")]
        public string DescripEmbalaje { get; init; }

        [JsonPropertyName("SectorCOFEPRIS")]
        public string SectorCOFEPRIS { get; init; }

        [JsonPropertyName("NombreIngredienteActivo")]
        public string NombreIngredienteActivo { get; init; }

        [JsonPropertyName("NomQuimico")]
        public string NomQuimico { get; init; }

        [JsonPropertyName("DenominacionGenericaProd")]
        public string DenominacionGenericaProd { get; init; }

        [JsonPropertyName("DenominacionDistintivaProd")]
        public string DenominacionDistintivaProd { get; init; }

        [JsonPropertyName("Fabricante")]
        public string Fabricante { get; init; }

        [JsonPropertyName("FechaCaducidad")]
        public DateTime? FechaCaducidad { get; init; }

        [JsonPropertyName("LoteMedicamento")]
        public string LoteMedicamento { get; init; }

        [JsonPropertyName("FormaFarmaceutica")]
        public string FormaFarmaceutica { get; init; }

        [JsonPropertyName("CondicionesEspTransp")]
        public string CondicionesEspTransp { get; init; }

        [JsonPropertyName("RegistroSanitarioFolioAutorizacion")]
        public string RegistroSanitarioFolioAutorizacion { get; init; }

        [JsonPropertyName("PermisoImportacion")]
        public string PermisoImportacion { get; init; }

        [JsonPropertyName("FolioImpoVUCEM")]
        public string FolioImpoVUCEM { get; init; }

        [JsonPropertyName("NumCAS")]
        public string NumCas { get; init; }

        [JsonPropertyName("RazonSocialEmpImp")]
        public string RazonSocialEmpImp { get; init; }

        [JsonPropertyName("NumRegSanPlagCOFEPRIS")]
        public string NumRegSanPlagCOFEPRIS { get; init; }

        [JsonPropertyName("DatosFabricante")]
        public string DatosFabricante { get; init; }

        [JsonPropertyName("DatosFormulador")]
        public string DatosFormulador { get; init; }

        [JsonPropertyName("DatosMaquilador")]
        public string DatosMaquilador { get; init; }

        [JsonPropertyName("UsoAutorizado")]
        public string UsoAutorizado { get; init; }


        [JsonPropertyName("PesoEnKg")]
        public decimal PesoEnKg { get; init; }

        [JsonPropertyName("ValorMercancia")]
        public decimal ValorMercancia { get; init; }

        [JsonPropertyName("Moneda")]
        public string Moneda { get; init; }

        [JsonPropertyName("FraccionArancelaria")]
        public string FraccionArancelaria { get; init; }

        [JsonPropertyName("UUIDComercioExt")]
        public string UUIDComercioExt { get; init; }
        [JsonPropertyName("TipoMaterial")]
        public string TipoMaterial { get; init; }

        [JsonPropertyName("DescripcionMaterial")]
        public string DescripcionMaterial { get; init; }

        [JsonPropertyName("DocumentacionAduanera")]
        public DocumentacionAduanera[] DocumentacionAduanera { get; init; }


        [JsonPropertyName("Pedimentos")]
        public Pedimentos[] Pedimentos { get; init; }

        [JsonPropertyName("GuiasIdentificacion")]
        public GuiasIdentificacion[] GuiasIdentificacion { get; init; }

        [JsonPropertyName("CantidadTransporta")]
        public CantidadTransporta[] CantidadTransporta { get; init; }

        [JsonPropertyName("DetalleMercancia")]
        public DetalleMercancia DetalleMercancia { get; init; }
    }
}
