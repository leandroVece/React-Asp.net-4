import React from "react";
import { AuthRouter, useAuth } from "../Auth";
import TableRow from "../TableRow";
import Loader from "../Loader"
import Paginacion from "../Paginacion";
import { useParams } from "react-router-dom";


const Usuarios = () => {
    const auth = useAuth();
    const param = useParams()

    auth.setUrl(`user/page/${param?.usuarioPage || 1}`)

    return (
        <section className="cuerpo">
            <AuthRouter>
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white">Seccion solo de administradores</h1>.
                </div>
                <h2>Esta solo se vera para cadetes o administradores</h2>

                {auth.loading && <Loader />}

                {auth.dbUser.data && (
                    <div>
                        <div>
                            <table className="table w-75 mx-auto">
                                <thead>
                                    <tr>
                                        <th className="w-25">Nombre</th>
                                        <th className="w-25">Rol</th>
                                        <th className="w-25">Editar</th>
                                        <th className="w-25">Eliminar</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {auth.dbUser.data.length > 0 ? (
                                        auth.dbUser.data.map((user, index) =>
                                            < TableRow
                                                key={index}
                                                user={user}
                                                deleteWithToken={auth.deleteWithToken}
                                            />
                                        )
                                    ) : (
                                        <tr>
                                            <td colSpan="2">Sin datos</td>
                                        </tr>)}
                                </tbody>
                            </table>
                        </div>

                        < Paginacion
                            totalPages={auth.dbUser.totalPages}
                            param={auth.dbUser.pageNumber}
                            url={"usuarios"}
                        />
                    </div>)
                }
            </AuthRouter>
        </section>
    );
}

export default Usuarios;
