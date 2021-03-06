# LanguageCourseAspNetWebAPI
This repository stores a RESTful Web API made with asc.net core and EF core wich uses Jwt Bearer token for authentication and documents the API with Swashbuckle Swagger

***Sobre o projeto: criação de uma nova Web API para uma empresa que oferece cursos de idiomas. ***

*Use cases e Use Stories*
 . Criação da base de dados: Criar uma base de dados utilizando o SQL Server Management Studio com no mínimo as seguintes tabelas: Aluno, Turma e Usuário. Essa última para controlar o acesso feito pela API.
 . API em C#: A API deve utilizar a estrutura MVC utilizando Entity Data Model (.edmx) ou DDD utilizando Code First Mapping.
 Use story: Banco de dados criado via paragidma Code First Mapping utilizando EF Migrations para exportar o banco para o MSSQL SERVER EXPRESS, com mapeamento de tabelas, restrições e tipos
  
 Os dados são manipulados utilizando o Entity Framework e a API possui os seguintes métodos:

Login 
CRUD de Aluno (cadastro, listagem, edição e exclusão) 
CRUD de Turma (cadastro, listagem, edição e exclusão)
Enviar script SQL de Insert de pelo menos 1 registro em cada CRUD.

Todos os métodos devem ser autorizados via token, a ser retornado no método de login.
Use story: tokenização via JWT Bearer
            var key = System.Text.Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
A comunicação com a API deve ser feita via Swagger.
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Language Courses API Documentation",
                        Description = "This is the documentation of the API using swagger dependency " +
                    "wich generates an API for consumeble REST Web API",
                        Version = "V1"
                    }); ;
            });
*Business Logic*
·   Aluno deve ser cadastrado com turma => builder.HasOne(turma).toMany(Alunos).IsRequired()
PostStudents()
{                if (student.ClassRoom == null)
                {
                    return BadRequest(new { message = "Não é possível criar um estudante" +
                        " sem turma cadastrada."
                    });
                }
}

·   Matrícula do aluno não pode ser repetida; => on configure { modelBuilder.Entity<Aluno>()
            .HasIndex(a => a.Matricula)
            .IsUnique(); }

·  Turma não pode ser excluída se possuir alunos =>                 if (classModel.Students != null)
                {
                    return BadRequest(new{message = "Não é permitido remover esta turma, " +
                    "pois ela ainda possui alunos."
                    });
                }
