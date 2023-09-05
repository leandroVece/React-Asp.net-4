// const Articulo = () => {
//     const [row, setRow] = useState([]);
//     var [inicio, setinicio] = useState(0);
//     var [final, setfinal] = useState(8);

//     useEffect(() => {
//         let array = []
//         for (let index = inicio; index < final; index++) {
//             array.push(index)
//         }
//         setRow(array)
//         inicio = setinicio(inicio + 8)
//         final = setfinal(final + 8)
//         console.log(row, inicio, final)
//     }, [])

//     const handelAdd = () => {
//         let array = []
//         for (let index = inicio; index < final; index++) {
//             console.log(index + "adsa")
//             array.push(index)
//         }
//         setRow([...row, ...array])
//         inicio = setinicio(inicio + 8)
//         final = setfinal(final + 8)
//         console.log(row, inicio, final)
//     }

//     //justify-content-center align-items-center
//     return (
//         <>
//             <div className="d-flex flex-row bd-highlight ">
//                 <SilderBar />
//                 <div className=" bd-highlight overflow-auto w-100 vh-100 mx-2 ">
//                     <div className="row-responsive-md mx-1 ">
//                         <div className="row  row-cols-xl-4  row-cols-lg-3  row-cols-md-2  row-cols-sm-2 g-4 ">
//                             {row.length > 0 ? (
//                                 row.map((index) => {
//                                     return <Card key={index} />
//                                 }
//                                 )) : (
//                                 <div>
//                                     <Card />
//                                     <Card />
//                                 </div>
//                             )}

//                         </div>
//                     </div>
//                     <button onClick={handelAdd}>Ver mas</button>
//                 </div>
//             </div >
//         </>
//     )
// }
// export default Articulo;

import React, { useEffect, useState } from "react"
import SilderBar from "./SilderBar";
import "./card.css"
import Card from "./card";
import { helpHttp } from "./../../Helper";
import Loader from "../Loader";
import { GlobalContext } from "../../ApiContext";

const InitialForm = {
    articuloName: "",
    categoriaName: "",
    PriceMin: null,
    PriceMax: null
}

const initialRow = {
    totalPages: 0,
    pageNumber: 0,
    data: [],
    succeeded: true,
    errors: null,
    message: ""
}

const Articulo = () => {
    const [row, setRow] = useState(initialRow);
    const [filtro, setFiltro] = useState(InitialForm);
    const [disable, setDisable] = useState(true);
    const urlLocal = "/articuloCategoria/filtro"

    const {
        db,
        setUrl,
        loading,
    } = React.useContext(GlobalContext)

    //mira si un objeto esta vacio
    setUrl("/articuloCategoria/categorias")
    const isObjectEmpty = (objectName) => {
        return (
            objectName &&
            Object.keys(objectName).length === 0 &&
            objectName.constructor === Object
        );
    };


    if (isObjectEmpty(filtro)) {
        setFiltro(InitialForm)
    }
    useEffect(() => {
        let options = {
            body: filtro,
            headers: { "content-type": "application/json" },
        };
        helpHttp().post(urlLocal, options).then((res) => {
            if (res.err) {
                //setError(res);
                setDisable(false)
            } else {
                setRow(res);
                setDisable(true)
            }
        })
    }, [filtro])

    useEffect(() => {
        if (row.totalPages == row.pageNumber) {
            setDisable(false)
        }
    })

    const handelAdd = () => {
        let options = {
            body: filtro,
            headers: { "content-type": "application/json" },
        };
        helpHttp().post(`${urlLocal}/${row.pageNumber + 1}`, options).then((res) => {
            if (res.err) {
                //setError(res);
            } else {
                var array = [...row.data, ...res.data]
                setRow({
                    ...row,
                    ["totalPages"]: res.totalPages,
                    ["pageNumber"]: res.pageNumber,
                    ["data"]: array
                }
                );
            }
        })
    }

    return (
        <>
            <div className="d-flex flex-row bd-highlight">
                <SilderBar
                    setFiltro={setFiltro}
                    filtro={filtro}
                    db={db}
                />
                <div className=" bd-highlight overflow-auto w-100 vh-100  ">
                    <div className="row-responsive-md mt-2">
                        <div className="row  row-cols-xl-4  row-cols-lg-3  row-cols-md-2  row-cols-sm-2 g-4  ">
                            {loading && <Loader />}
                            {row.data && (
                                row.data.length > 0 ? (
                                    row.data.map((data, index) =>
                                    (<Card key={index}
                                        data={data}
                                    />)
                                    )) : (
                                    <div>
                                        no hay datos
                                    </div>
                                ))}
                        </div>
                    </div>
                    {disable && (
                        <div className="d-grid gap-2 col-3 mx-auto my-4">
                            <button className="btn btn-outline-dark" type="button" onClick={handelAdd}>Ver mas</button>
                        </div>)
                    }
                </div>
            </div>
        </>
    )
}
export default Articulo;