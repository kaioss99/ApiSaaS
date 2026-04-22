using ApiSaas.Data;
using ApiSaas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Gerenciamento de planos de assinatura
/// </summary>
/// <remarks>
/// Planos definem os tipos de assinatura disponíveis no sistema,
/// incluindo nome e valor.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class PlanosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlanosController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET: api/planos - retorna a lista de planos
    /// </summary>
    /// <remarks>
    /// Retorna todos os planos disponíveis.
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plano>>> Get()
        => await _context.Planos.ToListAsync();

    /// <summary>
    /// GET: api/planos/{id} - retorna um plano por ID
    /// </summary>
    /// <remarks>
    /// Busca um plano específico pelo identificador.
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<ActionResult<Plano>> Get(int id)
    {
        var plano = await _context.Planos.FindAsync(id);
        if (plano == null) return NotFound();
        return plano;
    }

    /// <summary>
    /// POST: api/planos - cria um novo plano
    /// </summary>
    /// <remarks>
    /// Cria um novo plano no sistema.
    ///
    /// Exemplo:
    /// {
    ///   "nome": "Plano Premium",
    ///   "preco": 49.90
    /// }
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult<Plano>> Post(Plano plano)
    {
        _context.Planos.Add(plano);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = plano.Id }, plano);
    }

    /// <summary>
    /// PUT: api/planos/{id} - atualiza um plano existente
    /// </summary>
    /// <remarks>
    /// Atualiza os dados de um plano existente.
    ///
    /// O ID da URL deve ser igual ao ID do objeto enviado.
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Plano plano)
    {
        if (id != plano.Id) return BadRequest();

        _context.Entry(plano).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// DELETE: api/planos/{id} - remove um plano
    /// </summary>
    /// <remarks>
    /// Remove um plano do sistema.
    /// </remarks>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var plano = await _context.Planos.FindAsync(id);
        if (plano == null) return NotFound();

        _context.Planos.Remove(plano);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}