using OnlineShop.Application.DTOs.AppFiles;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappers
{
    public static class ProductImageMappers
    {
        public static List<ProductImage> ToProductImagesList(this List<AppFile> appFiles, Guid productId)
        {
            var productImages = new List<ProductImage>();

            if (appFiles != null && appFiles.Count > 0)
            {
                foreach (var appFile in appFiles)
                {
                    ProductImage productImage = new()
                    {
                        ProductId = productId,
                        Image = appFile
                    };
                    productImages.Add(productImage);
                }
            }

            return productImages;
        }
    }
}
