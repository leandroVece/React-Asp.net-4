const Input = ({ placeholder, name, value, handleChange }) => {

    return (
        <>
            <input
                type="tex"
                className="form-control"
                id={name}
                placeholder={placeholder}
                name={name}
                value={value || ''}
                onChange={(event) => handleChange(event)}
            />
            <label className="form-label" htmlFor={name}>{name}</label>
        </>
    )
}

export default Input