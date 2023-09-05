import React from "react"
import { GlobalContext } from "../../ApiContext";
import Loader from "../Loader";
import { useLocation, useNavigate } from "react-router-dom";
import { AuthRouter, useAuth } from "../Auth";

const TomarPedido = () => {
    const { state } = useLocation();
    const nav = useNavigate();
    const Auth = useAuth();

    Auth.setUrl("/api/cadetepedido")

    const {
        loading,
        updateWihtUrl
    } = React.useContext(GlobalContext)


    const Tomar = (id_cadete, data) => {
        delete data.nombre;
        const cp = {
            userForeingKey: id_cadete,
            pedidoForeingKey: data.id,
        }
        data.estado = "En camino";
        Auth.createWithToken(cp)
        updateWihtUrl(data, "/api/pedido")
        nav("/Cadete")
    }

    return (
        <>
            <AuthRouter>
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white ">Lista de pedidos</h1>
                </div>

                {loading && <Loader />}
                {Auth.dbUser && (
                    <table className='table table-striped w-75 mx-auto' aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>Obs</th>
                                <th>Estado</th>
                                <th>Cliente</th>
                                <th>Tomar</th>
                            </tr>
                        </thead>
                        <tbody>
                            {Auth.dbUser.length > 0 ?
                                (Auth.dbUser.map((data) =>
                                    <tr key={data.obs}>
                                        <td>{data.obs}</td>
                                        <td>{data.estado}</td>
                                        <td>{data.nombre}</td>
                                        <td>
                                            <button className="btn btn-outline-primary" onClick={() => Tomar(state.id, data)}>Tomar</button>
                                        </td>
                                    </tr>
                                )) : (
                                    <tr>
                                        <td colSpan="5">Sin datos</td>
                                    </tr>
                                )}
                        </tbody>
                    </table>
                )}
            </AuthRouter>
        </>
    )
}
export default TomarPedido;