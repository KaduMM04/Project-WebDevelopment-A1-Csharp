import React, { useState, useEffect } from "react";
import "./CarModal.css";


export default function CarModal({ isOpen, onClose, onSubmit, carToEdit}) {
   const [car, setCar] = useState({
        name: "",
        mark: "",
        yearManufacture: 0,
        type: "",
        imageUrl: "",
        engine: "",
        power: 0,
        maximumSpeed: 0,
        fuelType: "",
        transmission: "",
        doors: "",
        traction: "",
  });

  useEffect(() => {
    if (carToEdit) {
      setCar(carToEdit);
    } else {
      setCar({
        name: "",
        mark: "",
        yearManufacture: 0,
        type: "",
        imageUrl: "",
        engine: "",
        power: 0,
        maximumSpeed: 0,
        fuelType: "",
        transmission: "",
        doors: "",
        traction: "",
      });
    }
  }, [carToEdit]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCar((prev => ({ ...prev, [name]: value})));
  };

  const handleSubmit = () => {
    onSubmit(car); // seja novo ou editado
    onClose();
  };


  if (!isOpen) return null;

 return (
    <div className="modal-overlay">
      <div className="modal">
        <h2>{carToEdit ? "Edit Car" : "Register New Car"}</h2>
        <div className="modal-form">
          {Object.entries(car).map(([key, value]) => (
            <div key={key} className="form-group">
              <label htmlFor={key}>{key}</label>
              <input
                id={key}
                name={key}
                type={typeof value === "number" ? "number" : "text"}
                value={car[key]}
                onChange={handleChange}
                placeholder={typeof value === "number" ? key : ""}
                readOnly={key === "id"} 
              />
            </div>
          ))}
        </div>
        <div className="modal-actions">
          <button onClick={handleSubmit}>
            {carToEdit ? "Save Changes" : "Submit"}
          </button>
          <button onClick={onClose} className="cancel">
            Cancel
          </button>
        </div>
      </div>
    </div>
  );
}