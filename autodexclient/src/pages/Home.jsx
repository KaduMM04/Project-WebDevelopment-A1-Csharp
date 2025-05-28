import React, { useState, useEffect } from "react";
import CarCard from "../components/vehicleCard/carCard/CarCard";
import CarModal from "../components/vehicleModal/carModal/CarModal";
import MotorcycleCard from "../components/vehicleCard/motorcycleCard/MotorcycleCard";
import MotorcycleModal from "../components/vehicleModal/motorcycleModal/MotorcycleModal";
import "./Home.css";

export default function Home() {
  const [id, setId] = useState("");
  const [type, setType] = useState("Cars");
  const [result, setResult] = useState(null);
  const [error, setError] = useState("");

  const [isCarModalOpen, setIsCarModalOpen] = useState(false);
  const [carToEdit, setCarToEdit] = useState(null);
  const [isMotorcycleModalOpen, setIsMotorcycleModalOpen] = useState(false);
  const [motorcycleToEdit, setMotorcycleToEdit] = useState(null);

  const apiBase = "http://localhost:5125";

  useEffect(() => {
    setResult(null);
    setError("");
    setId("");
  }, [type]);

  const handleSearch = async () => {
    setError("");
    setResult(null);

    try {
      if (!id.trim()) {
        const res = await fetch(`${apiBase}/${type}`);
        if (!res.ok) throw new Error(`Failed to fetch all ${type}`);
        const data = await res.json();
        setResult({ type: "All", data });
        return;
      }

      const res = await fetch(`${apiBase}/${type}/${id}`);
      if (res.ok) {
        const data = await res.json();
        setResult({ type: type.slice(0, -1), data });
      } else {
        setError(`No ${type.slice(0, -1)} found with that ID.`);
      }
    } catch (e) {
      console.error(e);
      setError("Network error.");
    }
  };

  const handleEdit = (vehicle) => {
    if (type === "Cars") {
      setCarToEdit(vehicle);
      setIsCarModalOpen(true);
    }else if (type === "Motorcycles") {
    setMotorcycleToEdit(vehicle);
    setIsMotorcycleModalOpen(true);
  }
  };

  const handleDelete = async (vehicleId) => {
  if (!type) return;

  try {
    const res = await fetch(`${apiBase}/${type}/${vehicleId}`, {
      method: "DELETE",
    });

    if (res.ok) {
      // Atualizar estado local (remover veículo da lista exibida)
      if (result?.type === "All") {
        setResult((prev) => ({
          ...prev,
          data: prev.data.filter((v) => v.id !== vehicleId),
        }));
      } else {
        // Se for um único item, apaga da tela
        setResult(null);
      }
    } else {
      console.error("Failed to delete.");
    }
  } catch (error) {
    console.error(error);
  }
};



  const handleCarSubmit = async (car) => {
  const isEditing = !!car.id;
  const endpoint = isEditing ? `${apiBase}/Cars/${car.id}` : `${apiBase}/Cars`;
  const method = isEditing ? "PUT" : "POST";

  try {
    const res = await fetch(endpoint, {
      method,
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(car),
    });

    if (res.ok) {
      const savedCar = await res.json(); // resgata carro atualizado/criado do backend

      setResult((prev) => {
        if (!prev) {
          return { type: "Car", data: savedCar };
        }

        if (prev.type === "All") {
          if (isEditing) {
            // Atualiza carro existente
            return {
              ...prev,
              data: prev.data.map((c) => (c.id === savedCar.id ? savedCar : c)),
            };
          } else {
            // Adiciona novo carro
            return {
              ...prev,
              data: [...prev.data, savedCar],
            };
          }
        }

        // Se estava vendo um único carro, atualiza esse
        if (prev.type === "Car") {
          return { ...prev, data: savedCar };
        }

        return prev;
      });

      setIsCarModalOpen(false);
      setCarToEdit(null);
    } else {
      console.error("Failed to save car.");
    }
  } catch (err) {
    console.error(err);
  }
};

const handleMotorcycleSubmit = async (moto) => {
  const isEditing = !!moto.id;
  const endpoint = isEditing ? `${apiBase}/Motorcycles/${moto.id}` : `${apiBase}/Motorcycles`;
  const method = isEditing ? "PUT" : "POST";

  try {
    const res = await fetch(endpoint, {
      method,
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(moto),
    });

    if (res.ok) {
      const savedMoto = await res.json();

    setResult((prev) => {
      if (!prev) { 
        return { type: "Motorcycle", data: savedMoto };
      }

      if (prev.type === "All") { 
        if (isEditing) { 
          return {
            ...prev,
            data: prev.data.map((m) => (m.id === savedMoto.id ? savedMoto : m)),
          };
        } else { 
          return {
            ...prev,
            data: [...prev.data, savedMoto], 
          };
        }
      }

      if (prev.type === "Motorcycle") { 
        return { ...prev, data: savedMoto }; 
      }

      return prev;
    });

    setIsMotorcycleModalOpen(false);
    setMotorcycleToEdit(null);
    } else {
      console.error("Failed to save motorcycle.");
    }
  } catch (err) {
    console.error(err);
  }
};

  return (
    <div className="home-container">
      <h1>Auto Dex</h1>

      <div className="search-bar">
        <select
          className="option"
          value={type}
          onChange={(e) => setType(e.target.value)}
        >
          <option value="Cars">Cars</option>
          <option value="Motorcycles">Motorcycles</option>
        </select>
        <input
          type="text"
          placeholder="Enter vehicle ID"
          value={id}
          onChange={(e) => setId(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
        <button
          className="add-btn"
          onClick={() =>
            type === "Cars"
              ? setIsCarModalOpen(true)
              : setIsMotorcycleModalOpen(true)
          }
        >
          +
        </button>
      </div>

      {error && <p className="error">{error}</p>}

      {result && (
        <div className="result">
          {result.type === "Car" && (
            <CarCard
              car={result.data}
              onEdit={handleEdit}
              onDelete={() => handleDelete(result.data.id)}
            />
          )}

          {result.type === "Motorcycle" && (
            <MotorcycleCard
              motorcycle={result.data}
              onEdit={handleEdit}
              onDelete={() => handleDelete(result.data.id)}
            />
          )}

          {result.type === "All" && (
            <div className="vehicles-list">
              {type === "Cars" &&
                result.data.map((car) => (
                  <CarCard
                    key={car.id}
                    car={car}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                  />
                ))}
              {type === "Motorcycles" &&
                result.data.map((moto) => (
                  <MotorcycleCard
                    key={moto.id}
                    motorcycle={moto}
                    onEdit={handleEdit}
                    onDelete={() => handleDelete(moto.id)}
                  />
                ))}
            </div>
          )}
        </div>
      )}

      {type === "Cars" && (
        <CarModal
          isOpen={isCarModalOpen}
          onClose={() => {
            setIsCarModalOpen(false);
            setCarToEdit(null);
          }}
          onSubmit={handleCarSubmit}
          carToEdit={carToEdit}
        />
      )}

      {type === "Motorcycles" && (
        <MotorcycleModal
          isOpen={isMotorcycleModalOpen}
          onClose={() => {
            setIsMotorcycleModalOpen(false);
            setMotorcycleToEdit(null);
          }}
          onSubmit={handleMotorcycleSubmit}
          motorcycleToEdit={motorcycleToEdit}
          />
        )}

    </div>
  );
}
