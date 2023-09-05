const roles = [
    {
        type: 'admin',
        read: true,
        write: true,
        delete: true,
        actionCadete: true,
        actionCliente: true
    },
    {
        type: 'cadete',
        read: true,
        write: false,
        delete: false,
        actionCadete: true,
        actionCliente: false

    },
    {
        type: 'cliente',
        read: true,
        write: false,
        delete: false,
        actionCliente: true,
        actionCadete: false,
    }
]

export default roles;