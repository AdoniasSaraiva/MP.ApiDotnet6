using AutoMapper;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotnet6.Application.DTOs.Validations;
using MP.ApiDotnet6.Application.Services.Interface;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDTO>("Objeto PRODUTO deve ser informado");

            var result = new ProductDTOValidation().Validate(productDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDTO>("Problema na validação", result);

            var product = _mapper.Map<Product>(productDTO);
            var data = await _productRepository.CreateAsync(product);

            return ResultService.OK<ProductDTO>(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
        {
            var products = await _productRepository.GetAsync();
            return ResultService.OK<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return ResultService.Fail<ProductDTO>("Produto não encontrado");

            return ResultService.OK<ProductDTO>(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return ResultService.Fail("Produto Não Encontrado");

            await _productRepository.DeleteAsync(product);

            return ResultService.OK($"Produto do Id {id} foi deletado");
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var validation = new ProductDTOValidation().Validate(productDTO);
            if (!validation.IsValid)
                ResultService.RequestError("Problema de validação", validation);

            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado");

            product = _mapper.Map<ProductDTO, Product>(productDTO, product);

            await _productRepository.EditAsync(product);

            return ResultService.OK("Produto Editado");
        }
    }
}
