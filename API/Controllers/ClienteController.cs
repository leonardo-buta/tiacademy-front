using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Dto;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;

        public ClienteController(ClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarClienteDTO dto)
        {
            var cliente = new Cliente(dto);
            _repository.Cadastrar(cliente);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cliente = _repository.ObterPorId(id);

            if (cliente is not null)
            {
                var vendedorDTO = new ObterClienteDTO(cliente);
                return Ok(vendedorDTO);
            }
            else
                return NotFound(new { Mensagem = "Cliente não encontrado" });
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var clientes = _repository.Listar();
            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarClienteDTO dto)
        {
            var vendedor = _repository.ObterPorId(id);

            if (vendedor is not null)
            {
                vendedor.MapearAtualizarClienteDTO(dto);
                _repository.AtualizarCliente(vendedor);
                return Ok(vendedor);
            }
            else
            {
                return NotFound(new { Mensagem = "Cliente não encontrado" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var vendedor = _repository.ObterPorId(id);

            if (vendedor is not null)
            {
                _repository.DeletarCliente(vendedor);
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
            }
        }
    }
}