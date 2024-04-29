using pe.com.tiendita.bo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.tiendita.dal
{
    public class DALProducto
    {
        Conexion objconexion = new Conexion();

        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<BOProducto> MostrarProducto()
        {
            List<BOProducto> categorias = new List<BOProducto>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProducto";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    BOProducto objpro = new BOProducto();
                    BOCategoria objcat = new BOCategoria();
                    objpro.codigo = Convert.ToInt32(dr["codpro"].ToString());
                    objpro.nombre = dr["nompro"].ToString();
                    objpro.descripcion = dr["despro"].ToString();
                    objpro.precio = Convert.ToDouble(dr["prepro"].ToString());
                    objpro.cantidad = Convert.ToDouble(dr["canpro"].ToString());
                    objpro.estado = Convert.ToBoolean(dr["estpro"].ToString());
                    //para el codigo
                    objcat.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    //producto
                    objpro.categoria = objcat;
                    categorias.Add(objpro);
                }
                return categorias;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //public List<BOCategoria> MostrarCategoriaTodo()
        //{
        //    List<BOCategoria> categorias = new List<BOCategoria>();
        //    try
        //    {
        //        cmdcat = new SqlCommand();
        //        cmdcat.CommandType = CommandType.StoredProcedure;
        //        cmdcat.CommandText = "SP_MostrarCategoriaTodo";
        //        cmdcat.Connection = objconexion.Conectar();
        //        drcat = cmdcat.ExecuteReader();
        //        while (drcat.Read())
        //        {
        //            BOCategoria objgen = new BOCategoria();
        //            objgen.codigo = Convert.ToInt32(drcat["codcat"].ToString());
        //            objgen.nombre = drcat["nomcat"].ToString();
        //            objgen.estado = Convert.ToBoolean(drcat["estcat"].ToString());
        //            categorias.Add(objgen);
        //        }
        //        return categorias;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return null;
        //    }
        //    finally
        //    {
        //        objconexion.CerrarConexion();
        //    }
        //}

        //public bool RegistrarCategoria(BOCategoria bc)
        //{
        //    try
        //    {
        //        cmdcat = new SqlCommand();
        //        cmdcat.CommandType = CommandType.StoredProcedure;
        //        cmdcat.CommandText = "SP_RegistrarCategoria";
        //        cmdcat.Connection = objconexion.Conectar();

        //        cmdcat.Parameters.AddWithValue("@nombre", bc.nombre);
        //        cmdcat.Parameters.AddWithValue("@estado", bc.estado);

        //        res = cmdcat.ExecuteNonQuery();

        //        if (res == 1)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }
        //    finally
        //    {
        //        objconexion.CerrarConexion();
        //    }
        //}

        //public bool ActualizarCategoria(BOCategoria bc)
        //{
        //    try
        //    {
        //        cmdcat = new SqlCommand();
        //        cmdcat.CommandType = CommandType.StoredProcedure;
        //        cmdcat.CommandText = "SP_ActualizarCategoria";
        //        cmdcat.Connection = objconexion.Conectar();

        //        cmdcat.Parameters.AddWithValue("@codigo", bc.codigo);
        //        cmdcat.Parameters.AddWithValue("@nombre", bc.nombre);
        //        cmdcat.Parameters.AddWithValue("@estado", bc.estado);

        //        res = cmdcat.ExecuteNonQuery();

        //        if (res == 1)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }
        //    finally
        //    {
        //        objconexion.CerrarConexion();
        //    }
        //}

        //public bool EliminarCategoria(BOCategoria bc)
        //{
        //    try
        //    {
        //        cmdcat = new SqlCommand();
        //        cmdcat.CommandType = CommandType.StoredProcedure;
        //        cmdcat.CommandText = "SP_EliminarCategoria";
        //        cmdcat.Connection = objconexion.Conectar();

        //        cmdcat.Parameters.AddWithValue("@codigo", bc.codigo);

        //        res = cmdcat.ExecuteNonQuery();

        //        if (res == 1)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }
        //    finally
        //    {
        //        objconexion.CerrarConexion();
        //    }
        //}
    }
}
