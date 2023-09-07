import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
//const imgDb = require.context("D:/proyecto%20web%20c%20shrap/Asp.net%20react/Cadeteria%204/React-Asp.net-3/upload", true)


const Card = ({ data }) => {
    const { id, articulo, categorias } = data
    const nav = useNavigate()
    const [img, setImg] = useState();

    useState(() => {
        if (articulo.archivos[0]?.img)
            setImg("data:image/png;base64," + articulo.archivos[0]?.img)
        else
            setImg("./img/imgPendiente.jpg")
    }, [img])

    const handelError = (e) => {
        e.target.src = "./img/imgRota.jpg";
        e.target.onerror = null;
    }

    function fileExists(path) {
        fetch(path, { method: 'HEAD' })
            .then(response => {
                if (response.ok) {
                    console.log("Foto existe");
                }
                else {
                    console.log("Foto No existe");
                }
            });
    }

    console.log(fileExists(`./upload/${articulo.archivos[0]?.name}`));

    //.log(fileExists(`./img/imgPendiente.jpg`));

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
                        src={imgDb || "./img/imgPendiente.jpg"} alt="" /> */}
                    <img onError={handelError}
                        src={img} style={style.img} alt="" />
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