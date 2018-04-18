const Project = require('../models').Project;

module.exports = {
    index: (req, res) => {
        let projects = Project.findAll().then(projects=>{
            res.render("project/index", {"projects": projects})
        });


    },
    createGet: (req, res) => {
        res.render("project/create");
    },
    createPost: (req, res) => {
        let args = req.body.project;
        console.log(args);
        Project.create(args).then(()=>{
            res.redirect("/");
        })
    },
    editGet: (req, res) => {
        let id = req.params.id;

        Project.findById(id).then(project => {
            res.render("project/edit", {"project":project});
        })
    },

    editPost: (req, res) => {
        let id = req.params.id;
        let args = req.body.project;

        Project.findById(id).then(project=>{
            project.updateAttributes(args).then(()=>{
                res.redirect('/');
            })
        })
    },

    deleteGet: (req, res) => {
        let id = req.params.id;

        Project.findById(id).then(project => {
            res.render("project/delete", {"project":project});
        })
    },
    deletePost: (req, res) => {
        let id = req.params.id;

        Project.findById(id).then(project=>{
            project.destroy().then(()=>{
                res.redirect('/');
            })
        })
    }
};