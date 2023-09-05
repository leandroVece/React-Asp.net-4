import React, { useState, useEffect } from "react"
import Input from "./Input";

import "./form.css"
import { useAuth } from "../Auth";
import { useLocation, useNavigate } from "react-router-dom";

const InitialForm = {
    id: null,
    nombre: "",
    direccion: "",
    telefono: "",
    referencia: ""
}

const FormProfile = () => {
    const auth = useAuth()
    auth.setUrl("/profile")
    const [form, setForm] = useState(InitialForm);
    const [img, setImg] = useState("")
    const { state } = useLocation();
    const nav = useNavigate();

    useEffect(() => {

        if (state) {
            setForm(state['data']);
            if (state['data'].rolName == "cadete") {
                setImg("./img/cadete.png")
            } else {
                setImg("./img/pedido.jpg")
            }
        } else {
            setForm(InitialForm);
            setImg("./img/pedido.jpg")
        }
    }, [state])

    let array = Object.getOwnPropertyNames(form)

    const handleSubmit = (e) => {
        e.preventDefault();
        if (form.id == null) {
            form.userForeiKey = auth.cookies.get('id');
            auth.createWithToken(form)
        } else {
            auth.UpdateWithToken(form);
        }
        handleReset();
        nav('/profile')
    };

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value,
        });
    };

    const handleReset = () => {
        setForm(InitialForm);
    };

    return (
        <section className="gradient-form" >
            <div className="container py-5 h-75">
                <div className="row d-flex justify-content-center align-items-center h-75">
                    <div className="col-xl-10">
                        <div className="card rounded-3 text-black">
                            <div className="row g-0">
                                <div className="col-lg-6">
                                    <div className="card-body p-md-5 mx-md-4">
                                        <div className="text-center">
                                            <img src={img}
                                                style={{ width: '185px' }} alt="logo" />
                                            <h4 className="mt-1 mb-5 pb-1">We are The [name] Team</h4>
                                        </div>
                                        <form onSubmit={handleSubmit}>
                                            {array.map((d, index) => {
                                                if (d === 'id') return
                                                else {
                                                    return (
                                                        <div className="form-floating mb-3" key={`field-${index}`}>
                                                            <Input
                                                                placeholder={d}
                                                                name={d}
                                                                value={form[d]}
                                                                handleChange={handleChange}
                                                            />
                                                        </div>
                                                    );
                                                }
                                            })}
                                            <div className="d-flex align-items-center justify-content-center pb-4">
                                                <input className="btn btn-outline-danger" type="reset" value="Limpiar" onClick={handleReset} />
                                                <input className="btn btn-outline-danger" type="submit" value="Enviar" />
                                            </div>
                                        </form>
                                    </div>
                                </div>
                                <div className="col-lg-6 d-flex align-items-center gradient-custom-2">
                                    <div className="text-white px-3 py-4 p-md-5 mx-md-4">
                                        <h4 className="mb-4">We are more than just a company</h4>
                                        <p className="small mb-0">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                                            tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                                            exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div >
        </section >
    )
}

export default FormProfile;

