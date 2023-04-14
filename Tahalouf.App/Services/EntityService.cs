using Tahalouf.App.Helpers;
using Tahalouf.App.IService;
using Tahalouf.App.Models;
using static Tahalouf.App.Constants.Path;
namespace Tahalouf.App.Services
{
    public class EntityService : IEntityService
    {
        public List<Entity> GetEntitesWithAttributes()
        {
            string[] filePaths = Directory.GetFiles(EntitiesDirectoryPath, Constants.Constant.JsonExtension,
                                                    SearchOption.TopDirectoryOnly);
            var entityAttributes = new List<Entity>();
            List<Root> roots = new List<Root>();
            Parallel.ForEach(filePaths, (filePath) =>
            {
                var root = JsonHelpers.ReadFile<Root>(filePath);
                roots.Add(root);
            });
            SetEntityAttributes(entityAttributes, roots);
            return entityAttributes;
        }

        private static void SetEntityAttributes(List<Entity> entityAttributes, List<Root> roots)
        {
            foreach (var root in roots)
            {
                foreach (var domainSourceBinding in root.DomainSourceBindings)
                {
                    if (domainSourceBinding.Entity is not null)
                    {
                        entityAttributes.Add(new Entity
                        {

                            Name = domainSourceBinding.Entity.Name,
                            Attributes = domainSourceBinding.Entity.Attributes
                        });
                    }
                }
            }
        }
    }
}

