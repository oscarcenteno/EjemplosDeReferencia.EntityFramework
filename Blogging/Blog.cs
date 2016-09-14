﻿using System.Collections.Generic;

namespace EjemplosDeReferencia.EF.ConsoleApplication.Blogging
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
