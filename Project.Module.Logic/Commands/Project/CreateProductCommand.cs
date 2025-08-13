using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnTime.ResponseHandler.Models;
using OnTime.ResponseHandler.Models;


namespace OnTime.Module.Logic.Commands.Project
{
  
  
        public record CreateProductCommand(string Name, decimal Price) : IRequest<APIOperationResponse<Guid>>;

        public class CreateProductHandler : IRequestHandler<CreateProductCommand, APIOperationResponse<Guid>>
        {
            public async Task<APIOperationResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                // Simulate product creation
                var newProductId = Guid.NewGuid();

                return APIOperationResponse<Guid>.Success(newProductId, "Product created successfully");
            }
        }
    

}
