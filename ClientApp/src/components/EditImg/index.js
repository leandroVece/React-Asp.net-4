import React, { useRef, useState } from 'react';
import axios from "axios";

const MAXIMO_TAMANIO_BYTES = 3000000
const EditImg = (archivo) => {

    const [foto, setFoto] = useState([]);
    const defaultImg = useRef()
    const [imgFile, setImgFile] = useState("https://cdn-icons-png.flaticon.com/512/573/573119.png");

    const subirARchivos = (e) => {

        if (e.target.files[0].size > MAXIMO_TAMANIO_BYTES) {
            alert("una de las imagenes es demaciado grande")
            return;
        }
        setFoto([...foto, ...e.target.files])
        const reader = new FileReader()
        reader.onload = function (e) {
            setImgFile(e.target.result)
        }
        reader.readAsDataURL(e.target.files[0])
    }

    const handelSubmit = async (e) => {
        e.preventDefault();
        let formData = new FormData();
        for (let index = 0; index < foto.length; index++) {
            formData.append('foto', foto[index]);
        }
        await axios.post("/articuloCategoria", formData)
            .then(response => {
                setTimeout(function () {
                    alert("perfecto")
                }, 800);
            }).catch(err => console.log(err))
    }
    const handleReset = () => {
        setImgFile("https://cdn-icons-png.flaticon.com/512/573/573119.png");
        defaultImg.current.src = imgFile
    };


    return (
        <div>
            {/* <!-- Button trigger modal --> */}
            <button type="button" class="bg-transparent border-0 text-white" data-bs-toggle="modal" data-bs-target="#exampleModal">
                <i class="bi bi-pencil-square"></i>
            </button>

            {/* <!-- Modal --> */}
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">Editar Imagen</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <form onSubmit={handelSubmit}>
                            <div class="modal-body" className=' '>
                                <label htmlFor="img" className="d-flex justify-content-center">
                                    <img src={imgFile} ref={defaultImg} className="rounded-circle w-50" />
                                </label>
                                <input type="file" id="img"
                                    onChange={(e) => subirARchivos(e)}
                                    name="foto" style={{ display: "none", visibility: "hidden" }}
                                    accept="image/*" multiple />
                            </div>
                            <div class="modal-footer">
                                <button type="button" onClick={handleReset} class="btn btn-secondary" data-bs-dismiss="modal" >Close</button>
                                <button type="submit" class="btn btn-primary">Save changes</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div >
        </div >
    );
};


export default EditImg;