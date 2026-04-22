using ApiSaas.Data;
using ApiSaas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Gerenciamento de assinaturas do sistema
/// </summary>
/// <remarks>
/// Uma assinatura representa o vínculo entre um cliente e um plano.
/// Cada cliente pode possuir uma ou mais assinaturas ativas.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class AssinaturasController : ControllerBase
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Inicializa o controller de assinaturas
    /// </summary>
    public AssinaturasController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET: api/assinaturas - retorna a lista de assinaturas
    /// </summary>
    /// <remarks>
    /// Lista todas as assinaturas cadastradas.
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Assinatura>>> Get()
        => await _context.Assinaturas.ToListAsync();

    /// <summary>
    /// GET: api/assinaturas/{id} - retorna uma assinatura por ID
    /// </summary>
    /// <remarks>
    /// Busca uma assinatura específica.
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<ActionResult<Assinatura>> Get(int id)
    {
        var assinatura = await _context.Assinaturas.FindAsync(id);
        if (assinatura == null) return NotFound();
        return assinatura;
    }

    /// <summary>
    /// POST: api/assinaturas - cria uma nova assinatura
    /// </summary>
    /// <remarks>
    /// Cria uma assinatura vinculando cliente e plano.
    ///
    /// Regras:
    /// - ClienteId deve existir
    /// - PlanoId deve existir
    ///
    /// Exemplo:
    /// {
    ///   "clienteId": 1,
    ///   "planoId": 2,
    ///   "dataInicio": "2026-04-22T00:00:00"
    /// }
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult> Post(Assinatura assinatura)
    {
        var cliente = await _context.Clientes.FindAsync(assinatura.ClienteId);
        var plano = await _context.Planos.FindAsync(assinatura.PlanoId);

        if (cliente == null || plano == null)
            return BadRequest("Cliente ou Plano não existe");

        _context.Assinaturas.Add(assinatura);
        await _context.SaveChangesAsync();

        return Ok(assinatura);
    }

    /// <summary>
    /// PUT: api/assinaturas/{id} - atualiza uma assinatura
    /// </summary>
    /// <remarks>
    /// Atualiza os dados de uma assinatura existente.
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Assinatura assinatura)
    {
        if (id != assinatura.Id) return BadRequest();

        _context.Entry(assinatura).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// DELETE: api/assinaturas/{id} - remove uma assinatura
    /// </summary>
    /// <remarks>
    /// Exclui uma assinatura do sistema.
    /// </remarks>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var assinatura = await _context.Assinaturas.FindAsync(id);
        if (assinatura == null) return NotFound();

        _context.Assinaturas.Remove(assinatura);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}