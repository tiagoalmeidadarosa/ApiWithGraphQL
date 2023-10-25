using ApiWithGraphQL.GraphQL.Schemas;
using ApiWithGraphQL.Models;
using GraphQL;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithGraphQL.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly RootSchema _schema;

        public GraphQLController(RootSchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            //var inputs = query.Variables.ToInputs();

            var schema = _schema;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                //_.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
