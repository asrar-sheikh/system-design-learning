using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SingletonDP.Models;

public partial class Bank
{
    [Key]
    public int Id { get; set; }

    [StringLength(80)]
    public string BankNameWithAccount { get; set; } = null!;
}
