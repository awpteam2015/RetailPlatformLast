using CommonFrameWork.Domain.Entities;


namespace CommonFrameWork.Extensions.NHibernate.EntityMappings
{
    /// <summary>
    /// A shortcut of <see cref="EntityMap{TEntity,TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
    /// </summary>
    /// <typeparam name="TEntity">Entity map</typeparam>
    public abstract class EntityMap<TEntity> : EntityMap<TEntity, int> where TEntity : IEntity<int>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tableName">Table name</param>
        protected EntityMap(string tableName)
            : base(tableName)
        {

        }
    }

    //{"The following types may not be used as proxies:\nProject.Model.PermissionManager.UserInfoEntity: method get_IsDeleted should be 'public/protected virtual' or 'protected internal virtual'\nProject.Model.PermissionManager.UserInfoEntity: method set_IsDeleted should be 'public/protected virtual' or 'protected internal virtual'\nProject.Model.PermissionManager.UserInfoEntity: method get_PkId should be 'public/protected virtual' or 'protected internal virtual'\nProject.Model.PermissionManager.UserInfoEntity: method set_PkId should be 'public/protected virtual' or 'protected internal virtual'\nProject.Model.PermissionManager.UserInfoEntity: method get_Version should be 'public/protected virtual' or 'protected internal virtual'\nProject.Model.PermissionManager.UserInfoEntity: method set_Version should be 'public/protected virtual' or 'protected internal virtual'"}
}