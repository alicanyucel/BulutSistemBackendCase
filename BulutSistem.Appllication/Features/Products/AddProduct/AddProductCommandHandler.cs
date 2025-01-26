

using AutoMapper;
using GenericRepository;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;
using IUnitOfWork = BulutSistem.Domain.Repositories.IUnitOfWork;

namespace BulutSistem.Appllication.Features.Products.AddProduct
{
    internal sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, Result<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository; // Kategori repo ekliyoruz

        public AddProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICategoryRepository categoryRepository)  // Kategori repo parametre olarak ekliyoruz
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = categoryRepository;  // Kategori repo'yu sınıfa atıyoruz
        }

        public async Task<Result<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
           

            // Ürün oluşturma
            Product product = _mapper.Map<Product>(request);

            // Ürünü ekleyelim
            await _productRepository.AddAsync(product, cancellationToken);

            // Değişiklikleri kaydedelim
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<string>.Succeed("Product kaydı yapıldı");
        }
    }

}
