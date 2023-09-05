import React from "react"
import { GlobalContext } from "../../ApiContext";
import Loader from "../Loader";
import { useLocation, useNavigate } from "react-router-dom";
import { AuthRouter, useAuth } from "../Auth";

const ActionPedido = () => {
    const { state } = useLocation();
    const Auth = useAuth();

    Auth.setUrl("/api/cadetepedido/action/" + state.id)
    const nav = useNavigate();

    const {
        loading,
        updateWihtUrl,
        CreateWihtUrl,
        deleteWihtUrl
    } = React.useContext(GlobalContext)

    Auth.setUrl("/api/cadetepedido/action/" + state.id)

    const Entregar = (data) => {
        delete data.nombre;
        delete data.id
        delete data.userForeingKey
        data.id = data.pedidoForeingKey;
        delete data.pedidoForeingKey

        data.estado = "Entregado"

        const CC = {
            userForeingKey: state.id,
            profileForeingKey: data.clienteForeingKey,
        }

        CreateWihtUrl(CC, "api/historial")
        updateWihtUrl(data, "api/pedido")
        nav("/Cadete")
    }

    const Cancelar = (data) => {
        let isDelete = window.confirm(
            `¿Estás seguro de cancelar el pedido con id ${data.id}?`
        );
        if (isDelete) {
            Auth.deleteWithTokenAndUrl(data.id, "api/cadetepedido")

            delete data.id
            delete data.nombre;
            delete data.userForeingKey
            data.id = data.pedidoForeingKey;
            delete data.pedidoForeingKey

            data.estado = "Pendiente"

            updateWihtUrl(data, "api/pedido/")
            nav("/Cadete")
        } else {
            return;
        }
    }




    return (
        <>
            <AuthRouter>
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white">Lista de pedidos</h1>
                </div>
                {loading && <Loader />}
                {Auth.dbUser && (
                    <table className='table table-striped w-75 mx-auto' aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>Obs</th>
                                <th>Estado</th>
                                <th>Cliente</th>
                                <th>Entregar/Cancelar</th>
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
                                            <button className="btn btn-outline-primary" onClick={() => Entregar(data)}>Entregar</button>
                                            <button className="btn btn-outline-primary" onClick={() => Cancelar(data)}>Cancelar</button>
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
export default ActionPedido;