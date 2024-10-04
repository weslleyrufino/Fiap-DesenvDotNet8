using Fiap_Aula3_CadastroAlunosAPI.Interfaces;
using Fiap_Aula3_CadastroAlunosAPI.Logging;
using Fiap_Aula3_CadastroAlunosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_Aula3_CadastroAlunosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        //Forma 1 de Injeção
        private readonly IAlunoCadastro _alunoCadastro;
        private readonly ILogger<AtendimentoController> _logger;

        public AtendimentoController(IAlunoCadastro alunoCadastro, ILogger<AtendimentoController> logger)
        {
            _alunoCadastro = alunoCadastro;
            _logger = logger;
        }

        //Forma 3 de injeção
        [HttpGet("aluno")]
        public IActionResult GetAluno(IServiceProvider serviceProvider, int id) {
            var alunoCadastro = serviceProvider.GetRequiredService<IAlunoCadastro>();

            CustomLogger.Arquivo = true;
            _logger.LogInformation("Teste de Log do tipo information");

            return Ok();
        }

        //Forma 2 de injeção
        [HttpPost("inserirAluno")]
        public IActionResult PostInserirAluno([FromKeyedServices("AlunoKeyed")] IAlunoCadastro alunoCadastro, [FromBody] Aluno aluno)
        {
            alunoCadastro.CriarAluno(aluno);
            return Ok(aluno);
        }
    }
}
