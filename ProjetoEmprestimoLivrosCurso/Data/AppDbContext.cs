using Microsoft.EntityFrameworkCore;

namespace ProjetoEmprestimoLivrosCurso.Data;

//Criando o contexto AppDbContext, que tem que estar herdando do DbContext, que vem do pacote EntityFrameworkCore
public class AppDbContext : DbContext
{
    //Criando um construtor, como o nosso contexto vai servir como ponte, entre o nosso código C# e o nosso SQL Server
    //a gente precisa de alguma forma, passar opções e configurações pra esse nosso contexto, a qual é o banco que ele
    //tem que se conectar? qual o servidor? como que é a forma de autenticação?
    //Ao criar o construtor, basicamente quando a gente instância essa classe, a gente já passa as opções.
    //Ele recebe as opções de configuração
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
