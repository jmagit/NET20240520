using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Dominio.Entidades;

public partial class Product {
    public void Descatalogar() {

    }

    public override bool Equals(object? obj) {
        return obj is Product product &&
               ProductId == product.ProductId;
    }

    public override int GetHashCode() {
        return HashCode.Combine(ProductId);
    }
}