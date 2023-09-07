import React from "react";
import { useAuth } from "../Auth";
import { useNavigate } from "react-router-dom";

const Botones = (id) => {

    const auth = useAuth();
    const navigate = useNavigate();
    const idresul = id.id

    const HacerPedido = () => {
        //hacer un pedido
        navigate("/FormPedido", { state: { idresul } })
    }

    const TomarPedido = () => {
        navigate("/TomarPedido", { state: { idresul } })
    }
    const handelRedirect = () => {
        //pedido cancelado/completado
        navigate("/actionPedido", { state: { idresul } })
    }



    if (auth.cookies.get("rol") === "cadete") {
        return (
            <>
                <div className="mt-2 d-grid gap-2 d-md-flex justify-content-md-end">
                    <button className="btn bg-c-lite-green text-white"
                        onClick={TomarPedido} type="button">Tomar Pedido</button>
                    <button className="btn bg-c-lite-green text-white"
                        onClick={handelRedirect} type="button"> Cancelar/Entregar</button>
                </div>
            </>
        )
    }
    if (auth.cookies.get("rol") === "cliente") {
        return (
            <>
                <div className="mt-2 d-grid gap-2 d-md-flex justify-content-md-end">
                    <button className="btn bg-c-lite-green text-white"
                        onClick={HacerPedido} type="button">Nuevo Pedido</button>
                </div>
            </>
        )
    }
}


export default Botones;