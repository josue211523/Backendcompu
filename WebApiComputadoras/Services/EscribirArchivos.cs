namespace WebApiComputadoras.Services
{
    public class EscribirArchivos
    {
        private readonly string archivoPost = "nuevosRegistros.txt";
        private readonly string archivoGet = "registroConsultado.txt";

        private void EscribirPost(string msg)
        {
            var root = $@"wwwroot\{archivoPost}";
            using (StreamWriter sw = new StreamWriter(root, append: true))
            {
                sw.WriteLine(msg);
                sw.Close();
            }
        }

        public void DoWork_Post(string objeto)
        {
            EscribirPost(objeto);
        }

        private void EscribirGet(string msg)
        {
            var root = $@"wwwroot\{archivoGet}";
            using (StreamWriter sw = new StreamWriter(root, append: true))
            {
                sw.WriteLine(msg);
                sw.Close();
            }
        }

        public void DoWork_Get(string objeto)
        {
            EscribirGet(objeto);
        }
    }
}
