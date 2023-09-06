using System.Linq.Expressions;

namespace ContactsWebApplication.Repositories
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Permet d'ajouter une entitée à la BDD.
        /// </summary>
        /// <param name="entity">Entité à ajouter.</param>"
        /// <returns>Un booléen pour savoir si l'insertion a réussi.</returns>
        bool Add(TEntity entity);

        // READ

        TEntity? GetById(int entityId);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        // repository.Get(e => e.QuelqueChose == "quelquechose")

        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        //UPDATE

        /// <summary>
        /// Permet de modifier une entitée de la BDD.
        /// </summary>
        /// <param name="entity">Entité à modifier avec l'Id renseigné.</param>
        /// <returns>Un booléen pour savoir si la mise à jour a réussi.</returns>
        bool Update(TEntity entity);//bool Update(int id, TEntity entity);// autre signature possible


        //DELETE

        /// <summary>
        /// Permet de supprimer une entitée de la BDD avec son id.
        /// </summary>
        /// <param name="entityId">Id de l'entité à supprimer.</param>
        /// <returns>Un booléen pour savoir si la suppression a réussi.</returns>
        bool Delete(int entityId);
    }
}
