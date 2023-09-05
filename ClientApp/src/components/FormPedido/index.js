import React, { useEffect, useState } from "react"
import { GlobalContext } from "../../ApiContext";
import { useLocation, useNavigate } from "react-router-dom";
import { AuthRouter } from "../Auth";

const InitialForm = {
    id: null,
    ClienteForeingKey: null,
    obs: "",
    estado: "Pendiente",
}

const FormPedido = () => {

    let navigate = useNavigate();
    const {
        setUrl,
        createData,
        updateData,
    } = React.useContext(GlobalContext)

    setUrl('/api/pedido')

    const { state } = useLocation();

    const [form, setForm] = useState(InitialForm);

    useEffect(() => {
        if (state.data) {
            setForm(state.data);
        } else {
            setForm(InitialForm);
        }
    }, [state]);


    const handleSubmit = (e) => {
        e.preventDefault();
        if (form.id) {
            updateData(form);
        } else {
            form.ClienteForeingKey = state.idresul;
            createData(form)
        }

        handleReset();
        //navigate('/pedido', { replace: true })
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
        <>
            <AuthRouter>
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white">Formulario pedidos nuevos </h1>
                </div>
                <div className="row container justify-content-center align-items-center">
                    <div className="col-auto w-75  mt-2">
                        <form className="border p-3 form" onSubmit={handleSubmit}>
                            <div className="row g-4 form-group">
                                <div className="col-auto d-block ">
                                    <label htmlFor="obs" className="me-2"> Obs</label>
                                    <input value={form.obs} onChange={handleChange} name="obs" id="obs" />
                                </div>
                                <div className="col-auto ">
                                    <input className="btn btn-outline-primary" type="submit" value="Enviar" />
                                    <input className="btn btn-outline-primary" type="reset" value="Limpiar" onClick={handleReset} />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </AuthRouter>
        </>
    )
}

export default FormPedido;