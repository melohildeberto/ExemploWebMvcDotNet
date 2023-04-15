using System;
using System.Collections.Generic;

namespace WebApplicationBdFisrt.Models;

public partial class Aluno
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;
}
