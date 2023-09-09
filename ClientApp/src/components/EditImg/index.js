import React, { useRef, useState } from 'react';
import axios from "axios";

const MAXIMO_TAMANIO_BYTES = 3000000
const EditImg = ({ archivo, origen, id }) => {

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
        if (archivo == null) {
            for (let index = 0; index < foto.length; index++) {
                formData.append('foto', foto[index]);
            }
            await axios.post(`/api/archivo/${origen}/${id}`, formData)
                .then(response => {
                    setTimeout(function () {
                        //console.log(`/archivo/${origen}/${id}`);
                        alert("perfecto")
                    }, 300);
                }).catch(err => alert(err))
        }
        else {

            for (let index = 0; index < foto.length; index++) {
                formData.append('newFoto', foto[index]);
            }
            formData.append('foto', archivo.foto)

            await axios.put(`/api/archivo/${origen}/${id}`, formData)
                .then(response => {
                    setTimeout(function () {
                        alert("perfecto")
                    }, 300);
                }).catch(err => alert(err))
        }
    }


    const handleReset = () => {
        setImgFile("https://cdn-icons-png.flaticon.com/512/573/573119.png");
        defaultImg.current.src = imgFile
    };


    return (
        <div>
            {/* <!-- Button trigger modal --> */}
            <button type="button" className="bg-transparent border-0 text-white" data-bs-toggle="modal" data-bs-target="#exampleModal">
                <i className="bi bi-pencil-square"> Image</i>
            </button>

            {/* <!-- Modal --> */}
            <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="exampleModalLabel">Editar Imagen</h1>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <form onSubmit={handelSubmit}>
                            <div className="modal-body">
                                <label htmlFor="img" className="d-flex justify-content-center">
                                    <img src={imgFile} ref={defaultImg} className="rounded-circle w-50" />
                                </label>
                                <span className='text-primary'>Maximo 3 MB</span>
                                <input type="file" id="img"
                                    onChange={(e) => subirARchivos(e)}
                                    name="foto" style={{ display: "none", visibility: "hidden" }}
                                    accept="image/*" multiple />
                            </div>
                            <div className="modal-footer">
                                <button type="button" onClick={handleReset} className="btn btn-secondary" data-bs-dismiss="modal" >Close</button>
                                <button type="submit" className="btn btn-primary">Save changes</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div >
        </div >
    );
};


export default EditImg;