using System;
using System.Collections.Generic;

namespace WebApplicationBdFisrt.Models;

public partial class Professor
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
