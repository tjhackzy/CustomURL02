using System.Globalization;

namespace CustomURL01
{
  
    public class RequestURLMiddleware
    {
        private readonly RequestDelegate _next;
        IConfiguration _configuration;

        public RequestURLMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration; 
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ttt = context.Request;

            if (context.Request.Path.Value != null
                && context.Request.Path.Value.ToLower() != "/index"
                && context.Request.Path.Value.ToLower() != "/privacy"
                && context.Request.Path.Value != "/"
                && context.Request.Path.Value?.Contains(".css") == false
                && context.Request.Path.Value?.Contains(".js") == false
                ) 
            {

                String TableName = _configuration.GetSection("Settings:TableName").Value;

                string dbname = _configuration.GetSection("Settings:DBName").Value;

                DataOperation dtOp = new DataOperation();

                if (dtOp.InitializeDB(dbname))
                {
                    //dtOp.DeleteOldTable(dbname, TableName);    d

                    dtOp.CreateNewTableIfNotExist(dbname, TableName);

                    dtOp.InsertValue(dbname, TableName, 
                        new DataModels.URLMap("test",
                        @"<!DOCTYPE html>
                            <html lang=""en"">
                            <meta charset = ""UTF-8"">
                            <title> Test Page </title>
                            <meta name = ""viewport"" content = ""width =device-width,initial-scale=1"">
                            <link rel = ""stylesheet"" href = """">
                            <style>
                            </style >
                            <script src = """" ></script>
                            <body>
                            <div class="""" >
                             <h1>This is a Heading</h1>
                             <p>This is a paragraph.</p>
                             <p>This is another paragraph.</p>
                            </div>
                            </body>
                            </html>"));

                    List<DataModels.URLMap> mydta = dtOp.ReadAllValues(dbname, TableName);


                    string? plainURL = context.Request.Path.Value;

                    if (!string.IsNullOrEmpty(plainURL))
                    {
                        plainURL = plainURL.Replace("/", "");
                        plainURL = plainURL.ToLower();
                        if (mydta.Where(x => !string.IsNullOrEmpty(x.URLName) && x.URLName.ToLower() == plainURL) != null
                             && mydta.Where(x => !string.IsNullOrEmpty(x.URLName) && x.URLName.ToLower() == plainURL).LastOrDefault() != null
                             && mydta.Where(x => !string.IsNullOrEmpty(x.URLName) && x.URLName.ToLower() == plainURL).Last() != null)
                        {
                            DataModels.URLMap selectedMap = mydta.Where(x => x.URLName == plainURL).Last();

                            context.Response.StatusCode = StatusCodes.Status200OK; //Bad Request                
                            await context.Response.WriteAsync(selectedMap.URLValue ?? "no-data");
                            return;
                        }
                    }

                }
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("INVALID URL.");
                return;
            }


            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
    public static class RequestURLMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestURL(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestURLMiddleware>();
        }
    }
}
