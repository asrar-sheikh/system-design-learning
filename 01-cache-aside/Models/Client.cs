using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SingletonDP.Models;

public partial class Client
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("DOB")]
    public DateOnly? Dob { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string ContactNo { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string AadharNo { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Pan { get; set; } = null!;

    public int OfficeId { get; set; }

    [InverseProperty("Client")]
    public virtual ICollection<GeneralPolicy> GeneralPolicies { get; set; } = new List<GeneralPolicy>();
}
