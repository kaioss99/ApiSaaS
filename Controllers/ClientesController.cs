using ApiSaas.Data;
using ApiSaas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Gerenciamento de clientes do sistema
/// </summary>
/// <remarks>
/// Clientes representam usuários que podem contratar planos
/// e possuir assinaturas ativas.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET: api/clientes - retorna a lista de clientes
    /// </summary>
    /// <remarks>
    /// Retorna todos os clientes cadastrados no sistema.
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        => await _context.Clientes.ToListAsync();

    /// <summary>
    /// GET: api/clientes/{id} - retorna um cliente por ID
    /// </summary>
    /// <remarks>
    /// Busca um cliente específico pelo identificador.
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return NotFound();
        return cliente;
    }

    /// <summary>
    /// POST: api/clientes - cria um novo cliente
    /// </summary>
    /// <remarks>
    /// Cria um novo cliente no sistema.
    ///
    /// Exemplo:
    /// {
    ///   "nome": "João Silva",
    ///   "email": "joao@email.com"
    /// }
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult<Cliente>> Post(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    /// <summary>
    /// PUT: api/clientes/{id} - atualiza um cliente existente
    /// </summary>
    /// <remarks>
    /// Atualiza os dados de um cliente.
    ///
    /// O ID da URL deve ser igual ao ID do objeto enviado.
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();

        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// DELETE: api/clientes/{id} - remove um cliente
    /// </summary>
    /// <remarks>
    /// Remove um cliente do sistema com base no ID informado.
    /// </remarks>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return NotFound();

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}