import React, { useEffect } from "react";
import Loader from "../Loader";
import { GlobalContext } from "../../ApiContext";
import { useNavigate } from "react-router-dom";
import { AuthRouter, useAuth } from "../Auth";
import roles from "../../Rol";
import Paginacion from "../Paginacion";
import { useParams } from "react-router-dom";


const Cadete = () => {

    const navigate = useNavigate();
    const auth = useAuth();
    const param = useParams()

    auth.setUrl(`/user/cadete/page/${param?.cadetepage || 1}`)

    const handelRedirect = (id) => {
        navigate("/TomarPedido", { state: { id } })
    }
    const handelRedirectTo = (id) => {
        //pedido cancelado/completado
        navigate("/actionPedido", { state: { id } })
    }

    const handelEdit = (data) => {
        delete data.Id
        delete data.rolName
        data.id = data.profileForeikey
        delete data.profileForeikey
        navigate("/formProfile", { state: { data } })
    }

    var permisos = roles.find(rol => (rol.type === auth.cookies.get("rol")) ? rol : null);

    return (
        <section className="cuerpo">
            <AuthRouter>
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white ">Seccion de cadetes</h1>.
                </div >

                {auth.loading && <Loader />}

                {auth.dbUser.data && (
                    <div>

                        <div className="table-responsive-md mt-5">
                            <table className='table table-sm ' aria-labelledby="tabelLabel">
                                <thead className="table-borderless bg-dark bg-gradient">
                                    <tr className=" text-white">
                                        <th>Nombre</th>
                                        <th>Direccion</th>
                                        <th>Telefono</th>
                                        {permisos.write &&
                                            <th>Asignar pedido</th>
                                        }
                                        {permisos.write &&
                                            <th>Completar/Cancelar</th>
                                        }
                                        {permisos.write &&
                                            <th>Actualizar</th>
                                        }
                                        {
                                            permisos.delete &&
                                            <th>Borrar</th>
                                        }
                                    </tr>
                                </thead>
                                <tbody>
                                    {auth.dbUser.data.length > 0 ?
                                        (auth.dbUser.data.map((data) =>
                                            <tr key={data.nombre}>
                                                <td>{data.nombre}</td>
                                                <td>{data.direccion}</td>
                                                <td>{data.telefono}</td>
                                                {permisos.write &&
                                                    <td>
                                                        <button className="btn btn-outline-primary" onClick={() => handelRedirect(data.userForeiKey)}>Obtener</button>
                                                    </td>
                                                }
                                                {permisos.write &&
                                                    <td>
                                                        <button className="btn btn-outline-primary" onClick={() => handelRedirectTo(data.userForeiKey)}>Completar/Cancelar</button>
                                                    </td>
                                                }
                                                {permisos.write &&
                                                    <td>
                                                        <button className="btn btn-outline-primary" onClick={() => handelEdit(data)}>Editar</button>
                                                    </td>
                                                }
                                                {permisos.delete &&
                                                    <td>
                                                        <button className="btn btn-outline-primary" onClick={() => auth.deleteWithToken(data.id)}>Eliminar</button>
                                                    </td>
                                                }
                                            </tr>
                                        )) : (
                                            <tr>
                                                <td colSpan="6">Sin datos</td>
                                            </tr>
                                        )}
                                </tbody>
                            </table>
                        </div>
                        <Paginacion
                            totalPages={auth.dbUser.totalPages}
                            url={"cadete"}
                            param={auth.dbUser.pageNumber}
                        />
                    </div>
                )}
            </AuthRouter>
        </section>
    );
}

export default Cadete;