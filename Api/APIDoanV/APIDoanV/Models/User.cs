using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
