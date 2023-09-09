import React, { useEffect, useState } from "react";
import { AuthRouter, useAuth } from "../Auth";
import { useLocation, useNavigate } from "react-router-dom";
import { helpHttp } from "../../Helper";

const InitialForm = {
    userName: "",
    password: "",
    rolForeikey: null
}

const UpdateUser = () => {
    let { state } = useLocation()
    const auth = useAuth();
    const nav = useNavigate()
    auth.setUrl('/user/' + state.id_user)
    const [form, setForm] = useState(InitialForm);
    const [rol, setRol] = useState([]);

    useEffect(() => {
        let options = {
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + auth.cookies.get("Token")
            }
        };
        helpHttp().get("/user/rol", options).then((res) => {
            if (!res.err) {
                setRol(res)
                //setForm(auth.dbUser);
            } else {
                alert("Ocurrio un error Vuelva atra e intente de nuevo")
            }
        });
    }, [auth.url]);

    useEffect(() => {
        if (auth.dbUser) {
            setForm(auth.dbUser);
            form.password = ""
        } else {
            setForm(InitialForm);
        }
    }, [rol]);


    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        delete form.id
        let options = {
            body: form,
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + auth.cookies.get("Token")
            },
        };

        helpHttp().put(`/user/${auth.dbUser.id}`, options).then((res) => {
            if (!res.err) {
                nav('/usuarios')
            } else {
                alert("Ocurrio un error Vuelva atra e intente de nuevo")
            }
        });

    }


    return (
        <>
            <AuthRouter>
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white">Seccion solo de administradores</h1>.
                </div>
                <h2>Esta solo se vera para cadetes o administradores</h2>

                <div className="login-dark">
                    <form method="post" onSubmit={handleSubmit}>
                        <h2 className="sr-only">Update Form</h2>
                        <div className="illustration">
                            <i className="icon ion-ios-locked-outline"></i></div>
                        <div className="form-group">
                            <input className="form-control" type="text" name="userName" placeholder="New UserName" value={form?.userName} onChange={handleChange} />
                        </div>
                        <div className="form-group">
                            <input className="form-control" type="password" name="password" placeholder="New Password" value={form?.password} onChange={handleChange} />
                        </div>
                        <div className="form-group">
                            <select className="form-control" onChange={handleChange} name="rolForeikey" >
                                <option className="text-dark" value={form?.rolForeikey}>Elija un Rol</option>
                                {rol.length > 0 ?
                                    rol.map((x, index) => {
                                        return <option key={index} value={x.id} className="text-dark"
                                        > {x.rolName}</option>
                                    }) : null
                                }
                            </select>
                        </div>
                        <div className="form-group">
                            <button className="btn btn-primary btn-block" type="submit">Update</button>
                        </div>

                    </form>
                </div >
            </AuthRouter>
        </>
    );
}

export default UpdateUser;