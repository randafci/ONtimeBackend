using MediatR;
using OnTime.ResponseHandler.Models;


namespace OnTime.Module.Logic.Queries.Project
{


    public record GetProductByIdQuery(Guid Id) : IRequest<APIOperationResponse<ProductDto>>;

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, APIOperationResponse<ProductDto>>
    {
        // Normally, you'd inject a DbContext or Repository
        public async Task<APIOperationResponse<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            // Simulate data retrieval
            var product = new ProductDto
            {
                Id = request.Id,
                Name = "Sample Product",
                Price = 50.0m
            };

            if (product == null)
            {
                return APIOperationResponse<ProductDto>.NotFound("Product not found.");
            }

            return APIOperationResponse<ProductDto>.Success(product);
        }
    }

    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}


