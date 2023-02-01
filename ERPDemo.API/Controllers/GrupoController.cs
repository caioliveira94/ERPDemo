using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ERPDemo.API.ViewModels;
using ERPDemo.Domain.Entities;
using ERPDemo.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ERPDemo.API.Controllers
{
    public class GrupoController : BaseController
    {
        private readonly IGrupoService grupoService;
        private readonly IMapper mapper;

        public GrupoController(IMapper mapper, IGrupoService grupoService)
        {
            this.grupoService = grupoService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os grupos cadastrados.
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await grupoService.GetAllAsync();

                if (result is null)
                {
                    AddError("Nenhum grupo encontrado");
                    return CustomResponse();
                }
                else
                {
                    return CustomResponsePreserve(this.mapper.Map<IEnumerable<GrupoVMGet>>(result));
                }
            }
            catch (Exception e)
            {
                AddError("erro: " + e.Message);
                return CustomResponse();
            }
        }

        /// <summary>
        /// Retorna as informações de um grupo.
        /// </summary>
        /// <param name="id">Id do grupo</param>
        /// <returns>IActionResult</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            if (!IsValidId(id))
                return CustomResponse();

            try
            {
                var result = await grupoService.GetByIdAsync(id);

                if (result is null)
                {
                    AddError("Grupo não encontrado");
                    return CustomResponse();
                }
                else
                {
                    return CustomResponsePreserve(this.mapper.Map<GrupoVMGet>(result));
                }
            }
            catch (Exception e)
            {
                AddError("erro: " + e.Message);
                return CustomResponse();
            }
        }

        /// <summary>
        /// Cria um novo grupo.
        /// </summary>
        /// <param name="grupoPost">Dados do grupo a ser criado</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public async Task<IActionResult> Post(GrupoVMPost grupoPost)
        {
            if (IsArgumentNull(grupoPost))
                return CustomResponse();

            try
            {
                Grupo newgrupo = this.mapper.Map<Grupo>(grupoPost);
                await this.grupoService.AddAsync(newgrupo);

                return CustomResponsePreserve($"Grupo criado com sucesso");
            }
            catch (Exception e)
            {
                AddError("erro: " + e.Message);
                return CustomResponse();
            }
        }

        /// <summary>
        /// Altera as informações de um grupo.
        /// </summary>
        /// <param name="grupoPost">Dados do grupo a ser alterado</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        public async Task<IActionResult> Put(GrupoVMPost grupoPost)
        {
            if (IsArgumentNull(grupoPost))
                return CustomResponse();

            if (!IsValidId(grupoPost.Codigo.GetValueOrDefault()))
            {
                AddError($"Id {nameof(grupoPost.Codigo)} inválido");
                return CustomResponse();
            }

            try
            {
                Grupo grupo = this.mapper.Map<Grupo>(grupoPost);
                await this.grupoService.UpdateAsync(grupo);

                return CustomResponsePreserve(this.mapper.Map<GrupoVMPost>(grupo));
            }
            catch (Exception ex)
            {
                AddError("erro: " + ex.Message);
                return CustomResponse();
            }
        }

        /// <summary>
        /// Deleta um grupo.
        /// </summary>
        /// <param name="id">Id do grupo a ser removido</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!IsValidId(id))
            {
                AddError($"Id {nameof(id)} inválido");
                return CustomResponse();
            }

            try
            {
                await this.grupoService.DeleteAsync(id);

                return CustomResponse();
            }
            catch (Exception ex)
            {
                AddError("erro: " + ex.Message);
                return CustomResponse(false);
            }
        }

        /// <summary>
        /// Retorna os clientes associados ao grupo.
        /// </summary>
        /// <param name="grupoId">Id do grupo</param>
        /// <returns>IActionResult</returns>
        [HttpGet("GetClientesGrupo/{grupoId}")]
        public async Task<IActionResult> GetClientesGrupo(long grupoId)
        {
            try
            {
                var result = await this.grupoService.GetByIdAsync(grupoId);

                if (result.Clientes is null)
                {
                    AddError("Grupo sem clientes");
                    return CustomResponse();
                }
                else
                {
                    return CustomResponsePreserve(result.Clientes.ToList());
                }
            }
            catch (Exception e)
            {
                AddError("erro: " + e.Message);
                return CustomResponse();
            }
        }

    }
}
