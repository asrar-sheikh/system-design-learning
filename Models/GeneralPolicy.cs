using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SingletonDP.Models;

[Index("ClientId", Name = "IX_GeneralPolicies_ClientId")]
public partial class GeneralPolicy
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string PolicyId { get; set; } = null!;

    public int ClientId { get; set; }

    public DateOnly PolicyCreatedDate { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public int? CompanyId { get; set; }

    public int? BrokerId { get; set; }

    public int? OfficeId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Payment { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentMethod { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentType { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? AmountPaid { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? AmountBalance { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string VehicleNo { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? AccidentDateTime { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? CauseOfAccident { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DriverName { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? EstimatedClaimAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? FinalClaimAmount { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FinalSurveyorName { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? FinalSurveyorNumber { get; set; }

    [Column("IDV", TypeName = "decimal(18, 2)")]
    public decimal? Idv { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IntimateRefNo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LicenseNumber { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LicenseType { get; set; }

    public DateOnly? LicenseValidity { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MakeModel { get; set; }

    [Column("NCB", TypeName = "decimal(5, 2)")]
    public decimal? Ncb { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? PlaceOfAccident { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PolicyType { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? RebateAmount { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public int? SeatingCapacity { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SpotSurveyorName { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? SpotSurveyorNumber { get; set; }

    [Column("VehicleCC")]
    public int? VehicleCc { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? VehicleType { get; set; }

    public int? BankPaidFromId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CompanyAmountPaid { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CompanyPaymentMethod { get; set; } = null!;

    public bool PaidByCustomer { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? NetPremium { get; set; }

    [Column("ODPremium")]
    [StringLength(8)]
    [Unicode(false)]
    public string? Odpremium { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? TotalPremium { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? AgentName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BusinessType { get; set; }

    public DateOnly? FinalClaimDate { get; set; }

    [Column("NCBAmount", TypeName = "decimal(18, 2)")]
    public decimal? Ncbamount { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TransportName { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? EndorsementDetails { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? HypothecationDetails { get; set; }

    public bool? IsHypothecated { get; set; }

    public string? EndorsementHistory { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("GeneralPolicies")]
    public virtual Client Client { get; set; } = null!;
}
