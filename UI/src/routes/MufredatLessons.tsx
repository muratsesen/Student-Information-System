import React, { useEffect } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { fetchAllUsers } from "../features/user/userSlice";
import { Table } from "@mantine/core";
import {useMufredatDerslerQuery} from "../features/apiSlice"


const MufredatLessons = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  console.log(id);
 
  const { data: lessons, isError ,isLoading } = useMufredatDerslerQuery({id});
   console.log(lessons);

  const data =lessons?.length > 0 ? lessons?.map((lesson) => (
    <tr key={lesson.id}>
      <td>{lesson.id}</td>
      <td>{lesson.name}</td>
    </tr>
  )): (<tr> <td colSpan={2}>Henüz ders kaydı yok</td> </tr>);

  return (
    <div>
      <span className="text-blue-400 cursor-pointer"
        onClick={() => navigate(-1)}>
        Geri Dön
      </span>
      {isLoading ? (
        <h1>Fetching...</h1>
      ) : isError ? (
        Error
      ) : (
        <Table striped highlightOnHover withBorder withColumnBorders>
          <thead>
            <tr>
              <th>ID</th>
              <th>Ders Adı</th>
            </tr>
          </thead>
          <tbody>{data}</tbody>
        </Table>
      )}
    </div>
  );
};

export default MufredatLessons;
