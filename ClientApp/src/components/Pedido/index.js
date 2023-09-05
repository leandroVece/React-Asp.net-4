import React, { useEffect } from "react"
import { GlobalContext } from "../../ApiContext";
import Loader from "../Loader";
import { useNavigate } from "react-router-dom";
import { AuthRouter, useAuth } from "../Auth";
import Paginacion from "../Paginacion";
import { useParams } from "react-router-dom";
import roles from "../../Rol";



const Pedido = () => {
    const navigate = useNavigate();
    const param = useParams()
    const auth = useAuth()


    const {
        db,
        setUrl,
        loading,
        deleteWihtUrl
    } = React.useContext(GlobalContext)

    if ((auth.cookies.get("rol") === "cliente")) {
        if (param?.pedidoPage)
            setUrl(`/api/pedido/${auth.cookies.get("id_profile")}/page/${param?.pedidoPage}`)
        else
            setUrl(`/api/pedido/${auth.cookies.get("id_profile")}/page`)
    }
    else
        if (param?.pedidoPage)
            setUrl(`/api/pedido/page/${param?.pedidoPage}`)
        else
            setUrl(`/api/pedido/page`)


    const HandelEdit = (data) => {
        delete data.nombre
        navigate("/formPedido", { state: { data } })
    }

    const HandelDelete = (id) => {
        deleteWihtUrl(id, `/api/pedido/${id}`)
    }
    console.log(db);

    var permisos = roles.find(rol => (rol.type === auth.cookies.get("rol")) ? rol : null);

    return (
        <section className="cuerpo">
            <AuthRouter>
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white">Seccion de pedidos</h1>
                </div>

                {loading && <Loader />}
                {db.data && (
                    <div>
                        <div className="table-responsive-md mt-5">
                            <table className='table ' aria-labelledby="tabelLabel">
                                <thead className="table-borderless bg-dark bg-gradient">
                                    <tr className=" text-white">
                                        <th>Obs</th>
                                        <th>Estado</th>
                                        <th>Cliente</th>
                                        {permisos.actionCliente &&
                                            <th>Actualizar</th>
                                        }
                                        {permisos.actionCliente &&
                                            <th>Eliminar</th>
                                        }
                                    </tr>
                                </thead>
                                <tbody>
                                    {db.data.length > 0 ?
                                        (db.data.map((data) =>
                                            <tr key={data.obs}>
                                                <td>{data.obs}</td>
                                                <td>{data.estado}</td>
                                                <td>{data.nombre}</td>
                                                {permisos && permisos.actionCliente && (
                                                    <td>
                                                        <button className="btn btn-outline-primary" onClick={() => HandelEdit(data)}>Editar</button>
                                                    </td>)
                                                }
                                                {permisos.actionCliente && (
                                                    <td>
                                                        <button className="btn btn-outline-primary" onClick={() => HandelDelete(data.id_pedido)}>Eliminar</button>
                                                    </td>)
                                                }
                                            </tr>
                                        )) : (
                                            <tr>
                                                <td colSpan="5">Sin datos</td>
                                            </tr>
                                        )}
                                </tbody>
                            </table>
                        </div>
                        <Paginacion
                            totalPages={db.totalPages}
                            param={db.pageNumber}
                            url={"pedido"}
                        />
                    </div>
                )}
            </AuthRouter>
        </section>
    )
}
export default Pedido;