import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

const imgLocal = require.context("../../../public/upload", true)

const Card = ({ data }) => {
    const { id, articulo, categorias } = data
    const nav = useNavigate()

    const handelError = (e) => {
        e.target.src = "./img/imgRota.jpg";
        e.target.onerror = null;
    }


    const handelClick = () => {
        nav("/ArticuloDetail/" + id)
    }

    const style = {
        img: {
            widgh: "280px",
            height: "180px"
        }
    }

    return (
        <div className="col">
            <a onClick={handelClick}>
                <div className="card m-auto">
                    {/* <img onError={handelError}
                        src={imgDb || "./img/imgPendiente.jpg"} alt="" /> 
                    <img onError={handelError}
                        // src={imgLocal(`./${articulo.archivos[0]?.name}`) ||} style={style.img} alt="" />
                    */}
                    <img onError={handelError}
                        src={imgLocal(articulo.archivos[0]?.name ? `./${articulo.archivos[0]?.name}` : "./imgPendiente.jpg")} style={style.img} alt="" />
                    <div className="card-body">
                        <h6>{articulo.name}</h6>
                        <h6>${articulo.price}</h6>
                        <button className="btn btn-primary" >Add cart</button>
                    </div>
                </div>
            </a>
        </div>
    );
};

export default Card;