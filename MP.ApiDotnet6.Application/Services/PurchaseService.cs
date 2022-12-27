﻿using AutoMapper;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotnet6.Application.DTOs.Validations;
using MP.ApiDotnet6.Application.Services.Interface;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PurchaseDTO>> CreatePurchaseAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

            var validate = new PurchaseDTOValidation().Validate(purchaseDTO);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problema de validação", validate);

            var product = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);

            var purchase = new Purchase(product, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;

            return ResultService.OK<PurchaseDTO>(purchaseDTO);
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                return ResultService.Fail("Compra não encontrada");

            await _purchaseRepository.DeleteAsync(purchase);

            return ResultService.OK($"Compra Id:{id} Deletada");
        }

        public async Task<ResultService<ICollection<PurchaseDetailsDTO>>> GetAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync(); 
            return ResultService.OK(_mapper.Map<ICollection<PurchaseDetailsDTO>>(purchases));
        }

        public async Task<ResultService<PurchaseDetailsDTO>> GetByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                return ResultService.Fail<PurchaseDetailsDTO>("Compra não encontrada");
             
            return ResultService.OK(_mapper.Map<PurchaseDetailsDTO>(purchase));
        }

        public async Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

            var result = new PurchaseDTOValidation().Validate(purchaseDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de Validação", result);

            var purchase = await _purchaseRepository.GetByIdAsync(purchaseDTO.Id);
            if (purchase == null)
                return ResultService.Fail<PurchaseDTO>("Compra não encontrada");

            var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);

            purchase.Edit(purchase.Id,productId, personId);

            await _purchaseRepository.EditAsync(purchase);

            return ResultService.OK(purchaseDTO);
        }
    }   
}
