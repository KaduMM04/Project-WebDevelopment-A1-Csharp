import React, { useState, useEffect } from "react";
import "./MotorcycleModal.css";

export default function MotorcycleModal({ isOpen, onClose, onSubmit, motorcycleToEdit }) {
  const [motorcycle, setMotorcycle] = useState({
    name: "",
    mark: "",
    yearManufacture: "",
    type: "",
    imageUrl: "",
    engine: "",
    power: "",
    maximumSpeed: "",
    fuelType: "",
    transmission: "",
    engineDisplacement: "",
    typeHandlebar: "",
    brakeType: "",
    traction: "", 
  });

  useEffect(() => {
    if (motorcycleToEdit) {
      setMotorcycle(motorcycleToEdit);
    } else {
      setMotorcycle({
        name: "",
        mark: "",
        yearManufacture: "",
        engine: "",
        power: "",
        maximumSpeed: "",
        fuelType: "",
        transmission: "",
        traction: "",
      });
    }
  }, [motorcycleToEdit]);

  if (!isOpen) return null;

  const handleChange = (e) => {
    const { name, value } = e.target;
    setMotorcycle((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = () => {
    onSubmit(motorcycle);
  };

  return (
    <div className="modal-backdrop">
      <div className="modal-content">
        <h2>{motorcycleToEdit ? "Edit Motorcycle" : "Add Motorcycle"}</h2>
        {Object.entries(motorcycle).map(([key, value]) => (
          <input
            key={key}
            type="text"
            name={key}
            placeholder={key}
            value={value}
            onChange={handleChange}
          />
        ))}
        <div className="modal-buttons">
          <button onClick={handleSubmit}>Save</button>
          <button onClick={onClose}>Cancel</button>
        </div>
      </div>
    </div>
  );
}
