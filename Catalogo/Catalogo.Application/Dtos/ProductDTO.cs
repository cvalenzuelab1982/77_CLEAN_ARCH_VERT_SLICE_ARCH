﻿using Catalogo.Domain.Products;
using Microsoft.AspNetCore.Http;

namespace Catalogo.Application.Dtos
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this Product product, HttpContext context)
        {
            return new ProductDTO(
                product.Id,
                product.Name!,
                product.Descripcion!,
                product.Price ?? product.Price!.Value,
                $"{context.Request.Scheme}://{context.Request.Host}/images/{product.ImageUrl}",
                product.Code!,
                product.CategoryId
            );
        }
    }

    public sealed record ProductDTO(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string ImageUrl,
        string Code,
        Guid CategoryId
    );
}
