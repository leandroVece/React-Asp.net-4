import React, { useEffect, useState, useRef } from "react";
import "./formArt.css";
import { GlobalContext } from "../../ApiContext";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import axios from "axios"
import { useNavigate } from "react-router-dom";

const initialForm = {
    articuloName: "",
    price: 0,
    stock: 0,
    descripcion: "",
    categoriaName: "",
    archivo: []
}

const MAXIMO_TAMANIO_BYTES = 3000000

const FormArticulo = () => {

    const [form, setForm] = useState(initialForm);
    const [foto, setFoto] = useState([]);
    const [imgFile, setImgFile] = useState("https://cdn-icons-png.flaticon.com/512/573/573119.png");
    const current = useRef(1);
    const nav = useNavigate();

    const slidePageRef = useRef();
    const progressTextRef = useRef();
    const progressCheckRef = useRef();
    const bulletRef = useRef();
    const progressTextRef2 = useRef();
    const progressCheckRef2 = useRef();
    const bulletRef2 = useRef();
    const progressTextRef3 = useRef();
    const progressCheckRef3 = useRef();
    const bulletRef3 = useRef();
    const progressTextRef4 = useRef();
    const progressCheckRef4 = useRef();
    const bulletRef4 = useRef();

    const {
        db,
        setUrl,
        CreateWihtUrl
    } = React.useContext(GlobalContext)

    setUrl("/articuloCategoria/categorias")

    const ClassAdd = () => {
        switch (current.current) {
            case 1:
                bulletRef.current.classList.add("active");
                progressCheckRef.current.classList.add('active');
                progressTextRef.current.classList.add("active");
                break;
            case 2:
                bulletRef2.current.classList.add("active");
                progressCheckRef2.current.classList.add("active");
                progressTextRef2.current.classList.add("active");
                break;
            case 3:
                bulletRef3.current.classList.add("active");
                progressCheckRef3.current.classList.add("active");
                progressTextRef3.current.classList.add("active");
                break;
            case 4:
                bulletRef4.current.classList.add("active");
                progressCheckRef4.current.classList.add("active");
                progressTextRef4.current.classList.add("active");
                break;
            default:
                break;
        }
    }
    const ClassRemove = () => {
        switch (current.current) {
            case 1:
                bulletRef.current.classList.remove("active");
                progressCheckRef.current.classList.remove('active');
                progressTextRef.current.classList.remove("active");
                break;
            case 2:
                bulletRef2.current.classList.remove("active");
                progressCheckRef2.current.classList.remove("active");
                progressTextRef2.current.classList.remove("active");
                break;
            case 3:
                bulletRef3.current.classList.remove("active");
                progressCheckRef3.current.classList.remove("active");
                progressTextRef3.current.classList.remove("active");
                break;
            case 4:
                bulletRef4.current.classList.remove("active");
                progressCheckRef4.current.classList.remove("active");
                progressTextRef4.current.classList.remove("active");
                break;
            default:
                break;
        }
    }

    const HandelClick = (e) => {
        e.preventDefault();
        slidePageRef.current.style.marginLeft = `-${current.current * 25}%` //"-25%";
        ClassAdd();
        current.current++;
    }

    const HandelPreView = (e) => {
        e.preventDefault();
        var margin = (current.current === 1) ? "0%" : `-${(current.current - 2) * 25}%`
        slidePageRef.current.style.marginLeft = margin;
        current.current--;
        ClassRemove();
    }

    const handelSubmit = async (e) => {
        e.preventDefault();
        ClassAdd();
        let formData = new FormData();

        formData.append('ArticuloName', form.articuloName);
        formData.append('price', form.price);
        formData.append('categoriaName', form.categoriaName);
        formData.append('descripcion', form.descripcion);
        formData.append('stock', form.stock);
        for (let index = 0; index < foto.length; index++) {
            if (index >= 4) {
                alert("Maximo 4 imagenes")
                return;
            }
            formData.append('foto', foto[index]);
        }
        await axios.post("/articuloCategoria", formData)
            .then(response => {
                setTimeout(function () {
                    //console.log(response.data);
                    nav("/articulo")
                }, 800);
            }).catch(err => alert(err))
    }

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value,
        });
    };

    useEffect(() => {
        //current.current = 1
        //imgFile.current = "https://cdn-icons-png.flaticon.com/512/573/573119.png"
    }, [imgFile])

    const subirARchivos = (e) => {

        for (const iterator of e.target.files) {
            if (iterator.size > MAXIMO_TAMANIO_BYTES) {
                alert("una de las imagenes es demaciado grande")
                return;
            }
        }
        setFoto([...foto, ...e.target.files])
        const reader = new FileReader()
        reader.onload = function (e) {
            setImgFile(e.target.result)
        }
        reader.readAsDataURL(e.target.files[0])
    }

    return (
        <div className="body-form">
            <div className="container-articulo">
                <h1>Registrar Cliente</h1>
                <div className="progress-bar-art">
                    <div className="step-art">
                        <p ref={progressTextRef}>Paso 1</p>
                        <div className="bullet-art" ref={bulletRef}>
                            <span>1</span>
                        </div>
                        <div className="check fas fa-check" ref={progressCheckRef}></div>
                    </div>
                    <div className="step-art">
                        <p ref={progressTextRef2}>Paso 2</p>
                        <div className="bullet-art" ref={bulletRef2}>
                            <span>2</span>
                        </div>
                        <div className="check fas fa-check" ref={progressCheckRef2}></div>
                    </div>
                    <div className="step-art">
                        <p ref={progressTextRef3}>Paso 3</p>
                        <div className="bullet-art" ref={bulletRef3}>
                            <span>3</span>
                        </div>
                        <div className="check fas fa-check" ref={progressCheckRef3}></div>
                    </div>
                    <div className="step-art">
                        <p ref={progressTextRef4}>Fin</p>
                        <div className="bullet-art" ref={bulletRef4}>
                            <span>4</span>
                        </div>
                        <div className="check fas fa-check" ref={progressCheckRef4}></div>
                    </div>
                </div>

                {/* <!-- Formulario --> */}
                <div className="form-outer-art">
                    <form onSubmit={handelSubmit}>
                        <div className="page-art slide-page-art" ref={slidePageRef}>
                            <div className="field-art">
                                <label htmlFor="ArticuloName" className="label-art">Nombre del producto</label>
                                <input type="text" name="articuloName" id="articuloName" onChange={handleChange} value={form.articuloName} />
                            </div>
                            <div className="field-art">
                                <label htmlFor="price" className="label-art">Precio</label>
                                <input type="number" name="price" id="price" onChange={handleChange} value={form.price} />
                            </div>
                            <div className="field-art">
                                <label htmlFor="stock" className="label-art">Stock</label>
                                <input type="number" name="stock" id="stock" onChange={handleChange} value={form.stock} />
                            </div>
                            <div className="field-art">
                                <button className="firstNext next" onClick={HandelClick} >Siguiente</button>
                            </div>
                        </div>
                        <div className="page-art">
                            {/* //<div className="title">Información de Contacto</div> */}
                            <div className="field-art">
                                <label htmlFor="categoriaName1" className="label-art">Categoria</label>
                                <select className="form-select"
                                    onChange={handleChange} name="categoriaName" id="categoriaName1"
                                >
                                    <option defaultValue={""} placeholder="Select">Ninguno</option>
                                    {db.length > 0 ?
                                        (db.map((data) =>
                                            <option
                                                value={data.name}
                                                key={data.id}
                                            >{data.name}</option>
                                        )) : (
                                            <option>Error en Db</option >
                                        )}
                                </select>
                            </div>
                            <div className="field-art">
                                <label htmlFor="categoriaName" className="label-art">Nueva Categoria</label>
                                <input type="text" name="categoriaName" id="categoriaName" onChange={handleChange} value={form.categoriaName} />
                            </div>

                            <div className="field-art btns">
                                <button className="prev-1 prev" onClick={HandelPreView}>Atrás</button>
                                <button className="next-1 next" onClick={HandelClick}>Siguiente</button>
                            </div>
                        </div>
                        <div className="page-art">
                            <div className="">
                                <label htmlFor="img" className="label-art">
                                    <img src={imgFile} className="rounded-circle w-50" accept="image/*" />
                                </label>
                                <span>Tamaño maximo 3MB, hasta 4 Fotos</span>
                                <input type="file" id="img" value={form.archivo}
                                    onChange={(e) => subirARchivos(e)}
                                    name="foto" style={{ display: "none", visibility: "hidden" }}
                                    multiple />
                                {/* //   */}
                            </div>
                            <div className="field-art btns">
                                <button className="prev-2 prev" onClick={HandelPreView}>Atrás</button>
                                <button className="next-2 next" onClick={HandelClick}>Siguiente</button>
                            </div>
                        </div>
                        <div className="page-art">
                            <div className="field-art">
                                <label htmlFor="descripcion" className="label-art">Descripcion Del Producto</label>
                                <textarea name="descripcion" id="descripcion" onChange={handleChange} value={form.descripcion} cols="80" rows="3"></textarea>
                            </div>
                            <div className="field-art">
                            </div>
                            <div className="field-art btns">
                                <button className="prev-3 prev" onClick={HandelPreView}>Atrás</button>
                                <button className="submit">Enviar</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default FormArticulo;