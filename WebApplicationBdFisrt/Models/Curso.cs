using System;
using System.Collections.Generic;

namespace WebApplicationBdFisrt.Models;

public partial class Curso
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Ementa { get; set; } = null!;

    public decimal Valor { get; set; }

    public int IdProfessor { get; set; }

    public virtual Professor IdProfessorNavigation { get; set; } = null!;
}
