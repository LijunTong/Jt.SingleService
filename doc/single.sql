/*
 Navicat Premium Data Transfer

 Source Server         : 192.168.110.128_3306
 Source Server Type    : MySQL
 Source Server Version : 50743
 Source Host           : 192.168.110.128:3306
 Source Schema         : single

 Target Server Type    : MySQL
 Target Server Version : 50743
 File Encoding         : 65001

 Date: 21/08/2023 22:48:58
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for action
-- ----------------------------
DROP TABLE IF EXISTS `action`;
CREATE TABLE `action`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `controller` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '控制器',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT 'action',
  `text` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '文本',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of action
-- ----------------------------
INSERT INTO `action` VALUES ('16461658950272000', 'ArticleController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950288384', 'ArticleController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950288385', 'ArticleController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950288386', 'ArticleController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950288387', 'ArticleController', 'AddArticle', '发布文章', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950288388', 'CodeDbController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950288389', 'CodeDbController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950288390', 'CodeDbController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950288391', 'CodeDbController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304768', 'CodeGeneratorController', 'SetDb', '连接', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304769', 'CodeGeneratorController', 'CodeGenerator', '生成', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304770', 'CodeGenSchemeController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304771', 'CodeGenSchemeController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304772', 'CodeGenSchemeController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304773', 'CodeGenSchemeController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304774', 'CodeTempController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304775', 'CodeTempController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304776', 'CodeTempController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304777', 'CodeTempController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950304778', 'ColumnController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950304779', 'ColumnController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950304780', 'ColumnController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950304781', 'ColumnController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 1);
INSERT INTO `action` VALUES ('16461658950321152', 'MenuController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321153', 'MenuController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321154', 'MenuController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321155', 'MenuController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321156', 'MenuController', 'InitController', '更新权限数', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321157', 'RoleController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321158', 'RoleController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321159', 'RoleController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321160', 'RoleController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321161', 'RoleController', 'BindRoleActions', '分配权限', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321162', 'SysLogController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321163', 'SysLogController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321164', 'SysLogController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950321165', 'SysLogController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950337536', 'UserController', 'Insert', '新增', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950337537', 'UserController', 'Update', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950337538', 'UserController', 'Delete', '删除', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950337539', 'UserController', 'ListPager', '列表', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950337540', 'UserController', 'EditPassword', '修改密码', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950337541', 'UserController', 'BindUserRole', '分配角色', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);
INSERT INTO `action` VALUES ('16461658950337542', 'UserController', 'UpdateAvatar', '修改', '系统', '2023-08-21 22:25:27', '系统', '2023-08-21 22:25:27', 0);

-- ----------------------------
-- Table structure for code_db
-- ----------------------------
DROP TABLE IF EXISTS `code_db`;
CREATE TABLE `code_db`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '名称',
  `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '类型',
  `con_str` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '连接字符串',
  `user_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '用户id',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of code_db
-- ----------------------------
INSERT INTO `code_db` VALUES ('16235190598550528', 'framework', 'MySql', 'Server=192.168.159.128;Database=framework;Uid=root;Pwd=mysqlpassword;', '1', '1', '2023-03-14 22:49:56', '1', '2023-08-20 15:54:22', 1);
INSERT INTO `code_db` VALUES ('16459857586439168', 'cms', 'MySql', 'Server=192.168.110.128;Database=cms;Uid=root;Pwd=mysqlpwd;', '1', '1', '2023-08-20 15:53:01', '1', '2023-08-21 22:34:18', 0);

-- ----------------------------
-- Table structure for code_gen_scheme
-- ----------------------------
DROP TABLE IF EXISTS `code_gen_scheme`;
CREATE TABLE `code_gen_scheme`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '名称',
  `des` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '描述',
  `user_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '用户id',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of code_gen_scheme
-- ----------------------------
INSERT INTO `code_gen_scheme` VALUES ('16235207007994880', 'vue+element-ui前端方案', 'vue+element-ui前端方案', '1', '1', '2023-03-14 23:06:43', '1', '2023-03-14 23:06:50', 0);
INSERT INTO `code_gen_scheme` VALUES ('16235209982116864', 'framework后台模板生成方案', 'framework后台模板生成方案', '1', '1', '2023-03-14 23:09:39', '1', '2023-08-20 16:26:10', 0);

-- ----------------------------
-- Table structure for code_scheme_detials
-- ----------------------------
DROP TABLE IF EXISTS `code_scheme_detials`;
CREATE TABLE `code_scheme_detials`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `file_name` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '文件名称',
  `temp_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '模板id',
  `gen_scheme_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '生成方案id',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of code_scheme_detials
-- ----------------------------
INSERT INTO `code_scheme_detials` VALUES ('16235208199439360', 'src/api/{TableName}.js', '16235191285875712', '16235207007994880', '1', '2023-03-14 23:07:50', '1', '2023-03-14 23:07:50', 0);
INSERT INTO `code_scheme_detials` VALUES ('16235208291812352', 'src/views/{TableName}/index.vue', '16235191467901952', '16235207007994880', '1', '2023-03-14 23:07:56', '1', '2023-03-14 23:07:56', 0);
INSERT INTO `code_scheme_detials` VALUES ('16235209982166016', 'Jt.SingleService.Core/Tables/{ClassName}.cs', '16235191720985600', '16235209982116864', '1', '2023-03-14 23:09:39', '1', '2023-03-14 23:09:39', 1);
INSERT INTO `code_scheme_detials` VALUES ('16235209982166017', 'Jt.SingleService.Core/Tables/Mappers/{ClassName}Mapper.cs', '16235191915955200', '16235209982116864', '1', '2023-03-14 23:09:39', '1', '2023-03-14 23:09:39', 1);
INSERT INTO `code_scheme_detials` VALUES ('16235209982166018', 'Jt.SingleService.Core/Repositories/I{ClassName}Repo.cs', '16235192159683584', '16235209982116864', '1', '2023-03-14 23:09:39', '1', '2023-03-14 23:09:39', 1);
INSERT INTO `code_scheme_detials` VALUES ('16235209982166019', 'Jt.SingleService.Data/Repositories/{ClassName}Repo.cs', '16235192300913664', '16235209982116864', '1', '2023-03-14 23:09:39', '1', '2023-03-14 23:09:39', 1);
INSERT INTO `code_scheme_detials` VALUES ('16235209982166020', 'Jt.SingleService.Service/{ClassName}Svc/I{ClassName}Svc.cs', '16235192507614208', '16235209982116864', '1', '2023-03-14 23:09:39', '1', '2023-03-14 23:09:39', 1);
INSERT INTO `code_scheme_detials` VALUES ('16235209982166021', 'Jt.SingleService.Service/{ClassName}Svc/{ClassName}Svc.cs', '16235192635048960', '16235209982116864', '1', '2023-03-14 23:09:39', '1', '2023-03-14 23:09:39', 1);
INSERT INTO `code_scheme_detials` VALUES ('16235209982166022', 'Jt.SingleService/Controllers/{ClassName}Controller.cs', '16235192761156608', '16235209982116864', '1', '2023-03-14 23:09:39', '1', '2023-03-14 23:09:39', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887686878208', 'Jt.SingleService.Core/Tables/Mappers/{ClassName}Mapper.cs', '16235191915955200', '16235209982116864', '1', '2023-08-20 16:23:38', '1', '2023-08-20 16:23:38', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887686878209', 'Jt.SingleService.Core/Repositories/I{ClassName}Repo.cs', '16235192159683584', '16235209982116864', '1', '2023-08-20 16:23:38', '1', '2023-08-20 16:23:38', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887686878210', 'Jt.SingleService.Data/Repositories/{ClassName}Repo.cs', '16235192300913664', '16235209982116864', '1', '2023-08-20 16:23:38', '1', '2023-08-20 16:23:38', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887686878211', 'Jt.SingleService.Service/{ClassName}Svc/I{ClassName}Svc.cs', '16235192507614208', '16235209982116864', '1', '2023-08-20 16:23:38', '1', '2023-08-20 16:23:38', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887686878212', 'Jt.SingleService.Service/{ClassName}Svc/{ClassName}Svc.cs', '16235192635048960', '16235209982116864', '1', '2023-08-20 16:23:38', '1', '2023-08-20 16:23:38', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887686878213', 'Jt.SingleService/Controllers/{ClassName}Controller.cs', '16235192761156608', '16235209982116864', '1', '2023-08-20 16:23:38', '1', '2023-08-20 16:23:38', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887930721280', 'Jt.SingleService.Core/Tables/Mappers/{ClassName}Mapper.cs', '16235191915955200', '16235209982116864', '1', '2023-08-20 16:23:53', '1', '2023-08-20 16:23:53', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887930721281', 'Jt.SingleService.Core/Repositories/I{ClassName}Repo.cs', '16235192159683584', '16235209982116864', '1', '2023-08-20 16:23:53', '1', '2023-08-20 16:23:53', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887930721282', 'Jt.SingleService.Data/Repositories/{ClassName}Repo.cs', '16235192300913664', '16235209982116864', '1', '2023-08-20 16:23:53', '1', '2023-08-20 16:23:53', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887930721283', 'Jt.SingleService.Service/{ClassName}Svc/I{ClassName}Svc.cs', '16235192507614208', '16235209982116864', '1', '2023-08-20 16:23:53', '1', '2023-08-20 16:23:53', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887930721284', 'Jt.SingleService.Service/{ClassName}Svc/{ClassName}Svc.cs', '16235192635048960', '16235209982116864', '1', '2023-08-20 16:23:53', '1', '2023-08-20 16:23:53', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459887930721285', 'Jt.SingleService/Controllers/{ClassName}Controller.cs', '16235192761156608', '16235209982116864', '1', '2023-08-20 16:23:53', '1', '2023-08-20 16:23:53', 1);
INSERT INTO `code_scheme_detials` VALUES ('16459890185192448', 'Jt.SingleService.Core/Repositories/I{ClassName}Repo.cs', '16235192159683584', '16235209982116864', '1', '2023-08-20 16:26:10', '1', '2023-08-20 16:26:10', 0);
INSERT INTO `code_scheme_detials` VALUES ('16459890185192449', 'Jt.SingleService.Data/Repositories/{ClassName}Repo.cs', '16235192300913664', '16235209982116864', '1', '2023-08-20 16:26:10', '1', '2023-08-20 16:26:10', 0);
INSERT INTO `code_scheme_detials` VALUES ('16459890185192450', 'Jt.SingleService.Service/{ClassName}Svc/I{ClassName}Svc.cs', '16235192507614208', '16235209982116864', '1', '2023-08-20 16:26:10', '1', '2023-08-20 16:26:10', 0);
INSERT INTO `code_scheme_detials` VALUES ('16459890185192451', 'Jt.SingleService.Service/{ClassName}Svc/{ClassName}Svc.cs', '16235192635048960', '16235209982116864', '1', '2023-08-20 16:26:10', '1', '2023-08-20 16:26:10', 0);
INSERT INTO `code_scheme_detials` VALUES ('16459890185192452', 'Jt.SingleService/Controllers/{ClassName}Controller.cs', '16235192761156608', '16235209982116864', '1', '2023-08-20 16:26:10', '1', '2023-08-20 16:26:10', 0);

-- ----------------------------
-- Table structure for code_temp
-- ----------------------------
DROP TABLE IF EXISTS `code_temp`;
CREATE TABLE `code_temp`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `name` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '名称',
  `temp_content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '模板内容',
  `user_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '用户id',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of code_temp
-- ----------------------------
INSERT INTO `code_temp` VALUES ('16235191285875712', 'vue api模板', 'import request from \'@@/utils/request\'\n\nexport function list(userId) {\n    return request({\n        url: \'/@(Model.ClassName)/List\',\n        method: \'post\',\n        params: { userId: userId }\n    })\n}\n\nexport function listPager(data) {\n    return request({\n        url: \'/@(Model.ClassName)/listPager\',\n        method: \'post\',\n        params: data\n    })\n}\n\nexport function insert(data) {\n    return request({\n        url: \'/@(Model.ClassName)/Insert\',\n        method: \'post\',\n        data\n    })\n}\n\nexport function update(data) {\n    return request({\n        url: \'/@(Model.ClassName)/Update\',\n        method: \'post\',\n        data\n    })\n}\n\nexport function del(id) {\n    return request({\n        url: \'/@(Model.ClassName)/Delete\',\n        method: \'post\',\n        params: { id: id }\n    })\n}\n\nexport function get(id) {\n    return request({\n        url: \'/@(Model.ClassName)/Get\',\n        method: \'post\',\n        params: { id: id }\n    })\n}\n', '1', '1', '2023-03-14 22:50:38', '1', '2023-03-14 22:50:38', 0);
INSERT INTO `code_temp` VALUES ('16235191467901952', 'vue view模板', '<template>\n  <div class=\"app-container\">\n    <div class=\"table-tool\">\n      <el-tooltip content=\"详情\" placement=\"bottom\" effect=\"light\">\n        <el-button type=\"info\" size=\"mini\" @@click=\"details\"\n          ><i class=\"iconfont icon-eye\"></i\n        ></el-button>\n      </el-tooltip>\n      <el-tooltip content=\"添加\" placement=\"bottom\" effect=\"light\">\n        <el-button type=\"primary\" size=\"mini\" @@click=\"add\"\n          ><i class=\"iconfont icon-plus\"></i\n        ></el-button>\n      </el-tooltip>\n      <el-tooltip content=\"编辑\" placement=\"bottom\" effect=\"light\">\n        <el-button type=\"primary\" size=\"mini\" @@click=\"edit\"\n          ><i class=\"iconfont icon-edit\"></i\n        ></el-button>\n      </el-tooltip>\n      <el-tooltip content=\"删除\" placement=\"bottom\" effect=\"light\">\n        <el-button type=\"warning\" size=\"mini\" @@click=\"del\"\n          ><i class=\"iconfont icon-delete\"></i\n        ></el-button>\n      </el-tooltip>\n    </div>\n    <el-table\n      :data=\"tableData\"\n      ref=\"table\"\n      border\n      v-loading=\"tableLoading\"\n      height=\"530px\"\n      highlight-current-row\n      @@current-change=\"rowHandleCurrentChange\"\n    >\n      <el-table-column label=\"序号\" type=\"index\" width=\"55\" align=\"center\">\n        <template slot-scope=\"scope\">\n          <span>{{\n            (pagination.page - 1) * pagination.size + scope.$index + 1\n          }}</span>\n        </template>\n      </el-table-column>\n      @for(int i=0;i<Model.DbFieldInfos.Count;i++)\n	  {\n	   @if(Model.DbFieldInfos[i].FieldName==\"id\" || Model.DbFieldInfos[i].FieldName==\"add_time\" || Model.DbFieldInfos[i].FieldName==\"up_time\")\n          {\n            continue;\n          }\n		@:<el-table-column prop=\"@(Model.DbFieldInfos[i].FieldModelNameCamel)\" label=\"@(Model.DbFieldInfos[i].FieldDes)\"></el-table-column>\n	  }\n    </el-table>\n    <div class=\"table-pager\">\n      <el-pagination\n        @@size-change=\"handleSizeChange\"\n        @@current-change=\"handleCurrentChange\"\n        :current-page=\"pagination.page\"\n        :page-sizes=\"[10, 20, 50, 100, 500]\"\n        :page-size=\"pagination.size\"\n        layout=\"total, sizes, prev, pager, next, jumper\"\n        :total=\"pagination.total\"\n        background\n      >\n      </el-pagination>\n    </div>\n\n    <el-dialog\n      :title=\"dialogParams.title\"\n      :visible.sync=\"dialogParams.visible\"\n      :width=\"dialogParams.width\"\n      :close-on-click-modal=\"false\"\n      :close-on-press-escape=\"false\"\n      :show-close=\"false\"\n    >\n      <el-form\n        :model=\"formData\"\n        :rules=\"rules\"\n        ref=\"editForm\"\n        label-width=\"100px\"\n        v-show=\"dialogParams.type === 1 || dialogParams.type === 2\"\n      >\n	  @for(int i=0;i<Model.DbFieldInfos.Count;i++)\n	  {\n   			 @if(Model.DbFieldInfos[i].FieldName==\"id\" || Model.DbFieldInfos[i].FieldName==\"add_time\" || Model.DbFieldInfos[i].FieldName==\"up_time\")\n          {\n            continue;\n          }\n		<el-form-item label=\"@(Model.DbFieldInfos[i].FieldDes)\" prop=\"@(Model.DbFieldInfos[i].FieldModelNameCamel)\">\n		@if(Model.DbFieldInfos[i].FieldModelType == \"DateTime\")\n		{\n			<el-date-picker v-model=\"formData.@(Model.DbFieldInfos[i].FieldModelNameCamel)\" type=\"datetime\" placeholder=\"选择日期时间\"> </el-date-picker>\n		}\n		else if(Model.DbFieldInfos[i].FieldModelNameCamel.EndsWith(\"Id\") && Model.DbFieldInfos[i].FieldModelNameCamel != \"Id\")\n		{\n			<el-select v-model=\"formData.@(Model.DbFieldInfos[i].FieldModelNameCamel)\" placeholder=\"请选择\"><el-option v-for=\"item in [1,2,3]\" :key=\"item\" :label=\"item\" :value=\"item\"></el-option></el-select>\n		}\n		else if(Model.DbFieldInfos[i].FieldModelType.ToLower().Contains(\"int\"))\n		{\n			<el-input-number v-model=\"formData.@(Model.DbFieldInfos[i].FieldModelNameCamel)\"></el-input-number>\n		}\n		else if(Model.DbFieldInfos[i].FieldModelType.ToLower() == \"bool\" || Model.DbFieldInfos[i].FieldModelType.ToLower() == \"boolean\")\n		{\n			<el-radio v-model=\"formData.@(Model.DbFieldInfos[i].FieldModelNameCamel)\" :label=\"true\">是</el-radio>\n			<el-radio v-model=\"formData.@(Model.DbFieldInfos[i].FieldModelNameCamel)\" :label=\"false\">否</el-radio>\n		}\n		else\n		{\n			<el-input v-model=\"formData.@(Model.DbFieldInfos[i].FieldModelNameCamel)\"></el-input>\n		}\n		</el-form-item>\n		\n	  }\n		</el-form>\n      <span\n        slot=\"footer\"\n        class=\"dialog-footer\"\n        v-show=\"dialogParams.type === 1 || dialogParams.type === 2\"\n      >\n        <el-button @@click=\"formClose\">返 回</el-button>\n        <el-button\n          type=\"primary\"\n          @@click=\"dialogParams.type === 1 ? addSubmit() : editSubmit()\"\n          >提 交</el-button\n        >\n      </span>\n\n      <el-descriptions\n        class=\"margin-top\"\n        border\n        :column=\"2\"\n        v-show=\"dialogParams.type === 3\"\n      >\n		 @for(int i=0;i<Model.DbFieldInfos.Count;i++)\n		{\n          @if(Model.DbFieldInfos[i].FieldName==\"id\" || Model.DbFieldInfos[i].FieldName==\"add_time\" || Model.DbFieldInfos[i].FieldName==\"up_time\")\n          {\n            continue;\n          }\n          if(Model.DbFieldInfos[i].FieldModelType.ToLower() == \"bool\" || Model.DbFieldInfos[i].FieldModelType.ToLower() == \"boolean\")\n		{\n			@:<el-descriptions-item label=\"@(Model.DbFieldInfos[i].FieldDes)\">{{ formData.@(Model.DbFieldInfos[i].FieldModelNameCamel) ? \'是\':\'否\' }}</el-descriptions-item>\n		}\n		else\n		{\n			@:<el-descriptions-item label=\"@(Model.DbFieldInfos[i].FieldDes)\">{{ formData.@(Model.DbFieldInfos[i].FieldModelNameCamel) }}</el-descriptions-item>\n		}\n		}\n		</el-descriptions>\n      <span\n        slot=\"footer\"\n        class=\"dialog-footer\"\n        v-show=\"dialogParams.type === 3\"\n      >\n        <el-button @@click=\"formClose\" type=\"info\">确 认</el-button>\n      </span>\n    </el-dialog>\n  </div>\n</template>\n\n<script>\nimport * as api from \'@@/api/@(Model.TableName)\'\nexport default {\n  name: \'@(Model.TableName)\',\n  mounted() {\n    this.list()\n  },\n  data() {\n    return {\n      tableData: [],\n      tableLoading: false,\n      dialogParams: {\n        title: \'\',\n        visible: false,\n        width: \'50%\',\n        type: 1//1为新增，2为修改，3为详情\n      },\n      formData: {\n	  @for(int i=0;i<Model.DbFieldInfos.Count;i++)\n		{\n      @if(Model.DbFieldInfos[i].FieldName==\"id\" || Model.DbFieldInfos[i].FieldName==\"add_time\" || Model.DbFieldInfos[i].FieldName==\"up_time\")\n          {\n            continue;\n          }\n			@:@(Model.DbFieldInfos[i].FieldModelNameCamel):\'\',\n		}\n      },\n      pagination: {\n        size: 10,\n        page: 1,\n        total: 0,\n      },\n      rules: {\n		@for(int i=0;i<Model.DbFieldInfos.Count;i++)\n		{\n      @if(Model.DbFieldInfos[i].FieldName==\"id\" || Model.DbFieldInfos[i].FieldName==\"add_time\" || Model.DbFieldInfos[i].FieldName==\"up_time\")\n          {\n            continue;\n          }\n			if(Model.DbFieldInfos[i].IsNotNull == \"NO\")\n			{\n				@:@(Model.DbFieldInfos[i].FieldModelNameCamel): [{ required: true, message: \'@(Model.DbFieldInfos[i].FieldDes)不能为空\', trigger: \'blur\' }],\n			}\n		}\n      },\n      currentRow: null,\n      dbTypes: []\n\n    }\n  },\n  methods: {\n    formClose() {\n      this.dialogParams.visible = false;\n      this.$refs.editForm.resetFields()\n      this.formData = this.$options.data().formData\n    },\n    add() {\n      this.dialogParams.visible = true\n      this.dialogParams.title = \'新增\'\n      this.dialogParams.type = 1\n      this.getDbProvider()\n    },\n    edit() {\n      if (this.currentRow == null) {\n        this.$message.warning(\'请选择一条数据\')\n        return\n      }\n      this.dialogParams.visible = true\n      this.dialogParams.title = \'编辑\'\n      this.dialogParams.type = 2\n      let { id } = this.currentRow\n      api.get(id).then((res) => {\n        if (res.success) {\n          this.formData = res.data\n        }\n      })\n    },\n    details() {\n      if (this.currentRow == null) {\n        this.$message.warning(\'请选择一条数据\')\n        return\n      }\n      this.dialogParams.visible = true\n      this.dialogParams.title = \'详情\'\n      this.dialogParams.type = 3\n      let { id } = this.currentRow\n      api.get(id).then((res) => {\n        if (res.success) {\n          this.formData = res.data\n\n        }\n      })\n    },\n    del() {\n      if (this.currentRow == null) {\n        this.$message.warning(\'请选择数据\')\n        return\n      }\n      this.$confirm(\'此操作将永久删除数据, 是否继续?\', \'提示\', {\n        type: \'warning\'\n      }).then(() => {\n        let { id } = this.currentRow\n        api.del(id).then((res) => {\n          if (res.success) {\n            this.$message.success(\'删除成功\')\n            this.list()\n          }\n        })\n      });\n    },\n    list() {\n      this.tableLoading = true\n      api.listPager(this.pagination).then((res) => {\n        if (res.success) {\n          this.pagination.total = res.data.total\n          this.tableData = res.data.data\n        }\n        this.tableLoading = false\n      }).catch(() => {\n        this.tableLoading = false\n      })\n    },\n    addSubmit() {\n      this.$refs.editForm.validate(valid => {\n        if (valid) {\n          this.formData.userId = this.$store.getters.userId\n          api.insert(this.formData).then(res => {\n            if (res.success) {\n              this.$message.success(\'添加成功\')\n              this.list()\n              this.formClose()\n            }\n          })\n        }\n      })\n    },\n    editSubmit() {\n      this.$refs.editForm.validate(valid => {\n        if (valid) {\n          api.update(this.formData).then(res => {\n            if (res.success) {\n              this.$message.success(\'编辑成功\')\n              this.list()\n              this.formClose()\n            }\n          })\n        }\n      })\n    },\n    handleSizeChange(val) {\n      this.pagination.size = val\n      this.list()\n    },\n    handleCurrentChange(val) {\n      this.pagination.page = val\n      this.list()\n    },\n    rowHandleCurrentChange(val) {\n      this.currentRow = val;\n    }\n  }\n}\n</script>\n\n<style>\n</style>', '1', '1', '2023-03-14 22:50:49', '1', '2023-03-14 22:50:49', 0);
INSERT INTO `code_temp` VALUES ('16235191720985600', 'Jt.SingleService.Core.Tables模板', 'using System.ComponentModel.DataAnnotations.Schema;\n\nnamespace Jt.SingleService.Core.Tables\n{\n   [Table(\"@(Model.TableName)\")]\n    public class @(Model.ClassName) : BaseEntity\n    {\n        @for(int i = 0; i < Model.DbFieldInfos.Count;i++ )\n        {\n        	@:[Column(\"@(Model.DbFieldInfos[i].FieldName)\")]\n        	@:public @(Model.DbFieldInfos[i].FieldModelType) @(Model.DbFieldInfos[i].FieldModelName) { get; set; }\n\n        }\n    }\n}', '1', '1', '2023-03-14 22:51:04', '1', '2023-03-14 22:51:04', 0);
INSERT INTO `code_temp` VALUES ('16235191915955200', 'Jt.SingleService.Core.Tables.Mappers模板', 'using Jt.SingleService.Core.Tables;\nusing Microsoft.EntityFrameworkCore;\nusing Microsoft.EntityFrameworkCore.Metadata.Builders;\n\nnamespace Jt.SingleService.Core.Tables.Mappers\n{\n    public class @(Model.ClassName)Mapper : IEntityTypeConfiguration<@(Model.ClassName)>\n    {\n        public void Configure(EntityTypeBuilder<@(Model.ClassName)> builder)\n        {\n            builder.HasKey(m => m.Id);\n        }\n    }\n}', '1', '1', '2023-03-14 22:51:16', '1', '2023-03-14 22:51:16', 0);
INSERT INTO `code_temp` VALUES ('16235192159683584', 'Jt.SingleService.Core.Repositories模板', 'using Jt.SingleService.Core.Tables;\nusing Jt.SingleService.Core.Repositories;\n\nnamespace Jt.SingleService.Core.Repositories\n{\n    public interface I@(Model.ClassName)Repo : IBaseRepo<@(Model.ClassName)>\n    {\n\n    }\n}', '1', '1', '2023-03-14 22:51:31', '1', '2023-03-14 22:51:31', 0);
INSERT INTO `code_temp` VALUES ('16235192300913664', 'Jt.SingleService.Data.Repositories模板', 'using Jt.SingleService.Core.DbContexts;\nusing Jt.SingleService.Core.Repositories;\nusing Jt.SingleService.Core.Tables;\n\nnamespace Jt.SingleService.Data.Repositories\n{\n    public class @(Model.ClassName)Repo : BaseRepo<@(Model.ClassName)>, I@(Model.ClassName)Repo\n    {\n        public @(Model.ClassName)Repo (MysqlDbContext dbContext) : base(dbContext)\n        {\n\n        }\n    }\n}\n', '1', '1', '2023-03-14 22:51:40', '1', '2023-03-14 22:51:40', 0);
INSERT INTO `code_temp` VALUES ('16235192507614208', 'Jt.SingleService.IService模板', 'using Jt.SingleService.Core.Tables;\n\nnamespace Jt.SingleService.Service.@(Model.ClassName)Svc\n{\n    public interface I@(Model.ClassName)Svc : IBaseSvc<@(Model.ClassName)>\n    {\n        \n    }\n}', '1', '1', '2023-03-14 22:51:52', '1', '2023-03-14 22:51:52', 0);
INSERT INTO `code_temp` VALUES ('16235192635048960', 'Jt.SingleService.Service模板', 'using Jt.SingleService.Core.Repositories;\nusing Jt.SingleService.Core.Tables;\nusing Jt.SingleService.Service.@(Model.ClassName)Svc;\n\nnamespace Jt.SingleService.Service.UserSvc\n{\n    public class @(Model.ClassName)Svc : BaseSvc<@(Model.ClassName)>, I@(Model.ClassName)Svc\n    {\n        private readonly I@(Model.ClassName)Repo _repository;\n\n        public @(Model.ClassName)Svc(I@(Model.ClassName)Repo repository) : base(repository)\n        {\n            _repository = repository;\n        }\n    }\n}\n', '1', '1', '2023-03-14 22:52:00', '1', '2023-03-14 22:52:00', 0);
INSERT INTO `code_temp` VALUES ('16235192761156608', 'Jt.SingleService.Controllers模板', 'using Jt.SingleService.Core.Models;\nusing Jt.SingleService.Core.Jwt;\nusing Jt.SingleService.Core.Tables;\nusing Jt.SingleService.Core.Attributes;\nusing Jt.SingleService.Core.Enums;\nusing Jt.SingleService.Service.@(Model.ClassName)Svc;\nusing Microsoft.AspNetCore.Authorization;\nusing Microsoft.AspNetCore.Mvc;\nusing System;\n\nnamespace Jt.SingleService.Controllers\n{\n    [Route(\"@(Model.ClassName)\")]\n    public class @(Model.ClassName)Controller : BaseController\n    {\n        private readonly I@(Model.ClassName)Svc _service;\n        private readonly  JwtHelper _jwtHelper;\n        private readonly CHelperSnowflake _snowflake;\n\n        public @(Model.ClassName)Controller(I@(Model.ClassName)Svc service, JwtHelper jwtHelper,\n            CHelperSnowflake snowflake)\n        {\n            _service = service;\n           _jwtHelper = jwtHelper;\n           _snowflake = snowflake;\n        }\n\n        /// <summary>\n        /// 新增\n        /// </summary>\n        /// <returns></returns>\n        [HttpPost(\"Insert\")]\n        [Action(\"新增\", EnumActionType.AuthorizeAndLog)]\n        public async Task<ActionResult> Insert([FromBody] @(Model.ClassName) entity)\n        {\n            entity.Id = _snowflake.NextId().ToString();\n            entity.CreateTime = DateTime.Now;\n            entity.Creater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;\n            entity.UpTime = DateTime.Now;\n            entity.Updater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;\n            await _service.InsertAsync(entity);\n            return Ok(ApiResponse<bool>.GetSucceed(true));\n        }\n\n        /// <summary>\n        /// 修改\n        /// </summary>\n        /// <returns></returns>\n        [HttpPost(\"Update\")]\n        [Action(\"修改\", EnumActionType.AuthorizeAndLog)]\n        public async Task<ActionResult> Update([FromBody] @(Model.ClassName) entity)\n        {\n            entity.UpTime = DateTime.Now;\n            entity.Updater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;\n            await _service.UpdateAsync(entity);\n            return Ok(ApiResponse<bool>.GetSucceed(true));\n        }\n\n        /// <summary>\n        /// 删除\n        /// </summary>\n        /// <returns></returns>\n        [HttpPost(\"Delete\")]\n        [Action(\"删除\", EnumActionType.AuthorizeAndLog)]\n        public async Task<ActionResult> Delete(string id)\n        {\n            await _service.DeleteAsync(id);\n            return Ok(ApiResponse<bool>.GetSucceed(true));\n        }\n\n        /// <summary>\n        /// 通过id查询\n        /// </summary>\n        /// <returns></returns>\n        [HttpPost(\"Get\")]\n        public async Task<ActionResult> Get(string id)\n        {\n            var data = await _service.GetEntityByIdAsync(id);\n            return Ok(ApiResponse<@(Model.ClassName)>.GetSucceed(data));\n        }\n\n        /// <summary>\n        /// 查询\n        /// </summary>\n        /// <returns></returns>\n        [HttpPost(\"List\")]\n        public async Task<ActionResult> List()\n        {\n            var data = await _service.GetAllListAsync();\n            return Ok(ApiResponse<List<@(Model.ClassName)>>.GetSucceed(data));\n        }\n\n        /// <summary>\n        /// 分页查询\n        /// </summary>\n        /// <returns></returns>\n        [HttpPost(\"ListPager\")]\n        [Action(\"列表\", EnumActionType.AuthorizeAndLog)]\n        public async Task<ActionResult> ListPager([FromQuery] PagerReq pagerReq)\n        {\n            var data = await _service.GetPagerListAsync(pager: pagerReq);\n            PagerOutput pager = new PagerOutput()\n            {\n                Total = pagerReq.Total,\n                Data = data\n            };\n            return Ok(ApiResponse<PagerOutput>.GetSucceed(pager));\n        }\n    }\n}\n', '1', '1', '2023-03-14 22:52:08', '1', '2023-03-14 23:12:52', 0);
INSERT INTO `code_temp` VALUES ('16459860280968193', 'qqqqq', 'qqqqq111', '1', '1', '2023-08-20 15:55:45', '1', '2023-08-20 15:58:30', 1);

-- ----------------------------
-- Table structure for controller
-- ----------------------------
DROP TABLE IF EXISTS `controller`;
CREATE TABLE `controller`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '名称',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of controller
-- ----------------------------
INSERT INTO `controller` VALUES ('16235118653735936', 'CodeDbController', '系统', '2023-03-14 21:36:45', '系统', '2023-03-14 21:36:45', 0);
INSERT INTO `controller` VALUES ('16235118653735937', 'CodeGeneratorController', '系统', '2023-03-14 21:36:45', '系统', '2023-03-14 21:36:45', 0);
INSERT INTO `controller` VALUES ('16235134270080000', 'CodeGenSchemeController', '系统', '2023-03-14 21:52:38', '系统', '2023-03-14 21:52:38', 0);
INSERT INTO `controller` VALUES ('16235134270080001', 'CodeTempController', '系统', '2023-03-14 21:52:38', '系统', '2023-03-14 21:52:38', 0);
INSERT INTO `controller` VALUES ('16235134270080002', 'MenuController', '系统', '2023-03-14 21:52:38', '系统', '2023-03-14 21:52:38', 0);
INSERT INTO `controller` VALUES ('16235134270080003', 'RoleController', '系统', '2023-03-14 21:52:38', '系统', '2023-03-14 21:52:38', 0);
INSERT INTO `controller` VALUES ('16235134270080004', 'SysLogController', '系统', '2023-03-14 21:52:38', '系统', '2023-03-14 21:52:38', 0);
INSERT INTO `controller` VALUES ('16235134270080005', 'UserController', '系统', '2023-03-14 21:52:38', '系统', '2023-03-14 21:52:38', 0);
INSERT INTO `controller` VALUES ('16236574098310144', 'FileController', '系统', '2023-03-15 22:17:18', '系统', '2023-03-15 22:17:18', 1);
INSERT INTO `controller` VALUES ('16458441573860352', 'ArticleController', '系统', '2023-08-19 15:52:34', '系统', '2023-08-19 15:52:34', 1);
INSERT INTO `controller` VALUES ('16458441573860353', 'ColumnController', '系统', '2023-08-19 15:52:34', '系统', '2023-08-19 15:52:34', 1);

-- ----------------------------
-- Table structure for menu
-- ----------------------------
DROP TABLE IF EXISTS `menu`;
CREATE TABLE `menu`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `controller` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '控制器',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '名称',
  `title` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '标题',
  `path` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '路径',
  `redirect` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '重定向',
  `affix` bit(1) NOT NULL COMMENT '固定',
  `icon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '图标',
  `hidden` bit(1) NOT NULL COMMENT '隐藏',
  `sort_index` int(11) NOT NULL DEFAULT 0 COMMENT '排序',
  `type` smallint(11) NOT NULL DEFAULT 0 COMMENT '类型：0=后台，1=前台',
  `parent_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '上级菜单',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of menu
-- ----------------------------
INSERT INTO `menu` VALUES ('1', '', 'system', '系统管理', '/system', '/system', b'0', 'iconfont icon-setting', b'1', 3, 0, '', '系统', '2023-03-13 15:10:23', '系统', '2023-03-13 15:10:23', 0);
INSERT INTO `menu` VALUES ('16235161652659200', '无', 'dashboard', '首页', '/', '/dashboard', b'1', 'iconfont icon-dashboard', b'1', 1, 0, '', '1', '2023-03-14 22:20:29', '1', '2023-08-20 15:16:14', 0);
INSERT INTO `menu` VALUES ('16235174609306624', 'UserController', 'user', '用户管理', '/user', '/user', b'0', 'iconfont icon-user', b'1', 10, 0, '1', '1', '2023-03-14 22:33:40', '1', '2023-03-14 22:33:40', 0);
INSERT INTO `menu` VALUES ('16235175661601792', 'RoleController', 'role', '角色管理', '/role', '/role', b'0', 'iconfont icon-safetycertificate-f', b'1', 20, 0, '1', '1', '2023-03-14 22:34:44', '1', '2023-03-14 22:34:44', 0);
INSERT INTO `menu` VALUES ('16235178203644928', '无', 'user_info', '个人信息', '/user/info', '/user/info', b'0', '', b'0', 25, 0, '1', '1', '2023-03-14 22:37:19', '1', '2023-03-14 22:37:19', 0);
INSERT INTO `menu` VALUES ('16235179664507904', '无', 'log', '日志管理', '/log', '/log/Index', b'0', 'iconfont icon-reconciliation', b'1', 30, 0, '', '1', '2023-03-14 22:38:49', '1', '2023-03-14 22:40:06', 0);
INSERT INTO `menu` VALUES ('16235180812551168', 'SysLogController', 'sys_log', '系统日志', '/sys_log', '/sys_log', b'0', 'iconfont icon-read', b'1', 1, 0, '16235179664507904', '1', '2023-03-14 22:39:59', '1', '2023-03-14 22:39:59', 0);
INSERT INTO `menu` VALUES ('16235182563066880', '无', 'codegener', '代码平台', '/codegener', '/codegener', b'0', 'iconfont icon-code', b'1', 40, 0, '', '1', '2023-03-14 22:41:46', '1', '2023-03-14 22:41:46', 0);
INSERT INTO `menu` VALUES ('16235183238398976', 'CodeDbController', 'db', '数据源', '/code_db', '/code_db', b'0', 'iconfont icon-database', b'1', 1, 0, '16235182563066880', '1', '2023-03-14 22:42:27', '1', '2023-03-14 22:42:27', 0);
INSERT INTO `menu` VALUES ('16235183788983296', 'CodeTempController', 'code_temp', '模板', '/code_temp', '/code_temp', b'0', 'iconfont icon-file-text', b'1', 10, 0, '16235182563066880', '1', '2023-03-14 22:43:00', '1', '2023-03-14 22:43:00', 0);
INSERT INTO `menu` VALUES ('16235184418653184', 'CodeGenSchemeController', 'code_gen_scheme', '模板方案', '/code_gen_scheme', '/code_gen_scheme', b'0', 'iconfont icon-shop', b'1', 20, 0, '16235182563066880', '1', '2023-03-14 22:43:39', '1', '2023-03-14 22:44:15', 0);
INSERT INTO `menu` VALUES ('16235184863085568', 'CodeGeneratorController', 'code', '模板生成', '/code', '/code', b'0', 'iconfont icon-appstoreadd', b'1', 40, 0, '16235182563066880', '1', '2023-03-14 22:44:06', '1', '2023-03-14 22:44:06', 0);
INSERT INTO `menu` VALUES ('16459821852591104', '无', '1', '1', '1', '1', b'0', '', b'1', 1, 0, '', '1', '2023-08-20 15:16:40', '1', '2023-08-20 15:16:49', 1);
INSERT INTO `menu` VALUES ('2', 'MenuController', 'menus', '权限管理', '/menu', '/menu', b'0', 'iconfont icon-menu', b'1', 1, 0, '1', '系统', '2023-03-13 15:11:51', '1', '2023-03-14 22:05:23', 0);

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '名称',
  `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `des` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '描述',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES ('1', '超级管理员', 'Admin', '超级管理员', '超级管理员', '2023-03-13 11:54:09', '超级管理员', '2023-03-13 11:54:09', 0);
INSERT INTO `role` VALUES ('16235285555201024', '用户', 'user', '用户1', '1', '2023-03-15 00:26:32', '1', '2023-03-15 00:34:27', 0);
INSERT INTO `role` VALUES ('16459837886039040', '测试角色2', '100012', '10012', '1', '2023-08-20 15:32:58', '1', '2023-08-20 15:33:23', 1);

-- ----------------------------
-- Table structure for role_action
-- ----------------------------
DROP TABLE IF EXISTS `role_action`;
CREATE TABLE `role_action`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `role_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '角色id',
  `controller` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '控制器',
  `action` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT 'action',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of role_action
-- ----------------------------
INSERT INTO `role_action` VALUES ('16459838170153984', '16459837886039040', 'dashboard', 'Display', '1', '2023-08-20 15:33:16', '1', '2023-08-20 15:33:16', 0);
INSERT INTO `role_action` VALUES ('16459838170153985', '16459837886039040', 'MenuController', 'Display', '1', '2023-08-20 15:33:16', '1', '2023-08-20 15:33:16', 0);
INSERT INTO `role_action` VALUES ('16459838170153986', '16459837886039040', 'MenuController', 'Insert', '1', '2023-08-20 15:33:16', '1', '2023-08-20 15:33:16', 0);
INSERT INTO `role_action` VALUES ('16459838170153987', '16459837886039040', 'MenuController', 'Update', '1', '2023-08-20 15:33:16', '1', '2023-08-20 15:33:16', 0);
INSERT INTO `role_action` VALUES ('16459838170153988', '16459837886039040', 'MenuController', 'Delete', '1', '2023-08-20 15:33:16', '1', '2023-08-20 15:33:16', 0);
INSERT INTO `role_action` VALUES ('16459838170153989', '16459837886039040', 'MenuController', 'ListPager', '1', '2023-08-20 15:33:16', '1', '2023-08-20 15:33:16', 0);
INSERT INTO `role_action` VALUES ('16459838170153990', '16459837886039040', 'MenuController', 'InitController', '1', '2023-08-20 15:33:16', '1', '2023-08-20 15:33:16', 0);

-- ----------------------------
-- Table structure for sys_log
-- ----------------------------
DROP TABLE IF EXISTS `sys_log`;
CREATE TABLE `sys_log`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `type` int(11) NOT NULL DEFAULT 0 COMMENT '日志类型',
  `title` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '日志标题',
  `content` varchar(2000) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '日志内容',
  `log_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '操作时间',
  `user_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '操作人',
  `remote_address` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '用户ip',
  `controller` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '控制器',
  `action` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '操作',
  `param` varchar(2000) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '参数',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_log
-- ----------------------------
INSERT INTO `sys_log` VALUES ('16458456257561600', 1, '修改', '/User/UpdateAvatar POST', '2023-08-19 16:07:30', '1', '0.0.0.1', 'User', 'UpdateAvatar', '{\"entity\":{\"UserName\":\"admin\",\"Password\":null,\"RegisterTime\":\"2023-03-13T19:51:29\",\"LoginTime\":\"2023-08-19T16:05:58\",\"Status\":0,\"Avatar\":\"Files\\\\Avatars\\\\5e09a9_Joont.jpg\",\"UserRoles\":[{\"RoleId\":\"1\",\"UserId\":\"1\",\"User\":{\"UserName\":\"admin\",\"Password\":\"C3A10AC39C3949C2BA59C2ABC2BE56C3A057C3B20FC2883E\",\"RegisterTime\":\"2023-03-13T19:51:29\",\"LoginTime\":\"2023-08-19T16:05:58\",\"Status\":0,\"Avatar\":\"Files/Avatars/c97272_wallhaven-4g8x23.jpg\",\"UserRoles\":null,\"UserFollows\":[],\"FollowUsers\":null,\"ArticleCollects\":null,\"ArticleComments\":null,\"ArticleLikes\":null,\"ArticleReads\":null,\"CommentLikes\":null,\"Id\":\"1\",\"Creater\":\"超级管理员\",\"CreateTime\":\"2023-03-13T11:54:40\",\"Updater\":\"超级管理员\",\"UpTime\":\"2023-08-19T16:05:58\",\"IsDel\":0},\"Role\":{\"Name\":\"超级管理员\",\"Code\":\"Admin\",\"Des\":\"超级管理员\",\"RoleActions\":null,\"UserRoles\":[],\"Id\":\"1\",\"Creater\":\"超级管理员\",\"CreateTime\":\"2023-03-13T11:54:09\",\"Updater\":\"超级管理员\",\"UpTime\":\"2023-03-13T11:54:09\",\"IsDel\":0},\"Id\":\"1\",\"Creater\":\"超级管理员\",\"CreateTime\":\"2023-03-13T11:54:56\",\"Updater\":\"超级管理员\",\"UpTime\":\"2023-03-13T11:54:56\",\"IsDel\":0}],\"UserFollows\":[],\"FollowUsers\":null,\"ArticleCollects\":null,\"ArticleComments\":null,\"ArticleLikes\":null,\"ArticleReads\":null,\"CommentLikes\":null,\"Id\":\"1\",\"Creater\":null,\"CreateTime\":\"0001-01-01T00:00:00\",\"Updater\":null,\"UpTime\":\"0001-01-01T00:00:00\",\"IsDel\":0}}', 'LogAction', '2023-08-19 16:07:30', 'LogAction', '2023-08-19 16:07:30', 0);
INSERT INTO `sys_log` VALUES ('16458456541758464', 1, '列表', '/User/listPager POST', '2023-08-19 16:07:47', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-19 16:07:47', 'LogAction', '2023-08-19 16:07:47', 0);
INSERT INTO `sys_log` VALUES ('16458456564761600', 1, '列表', '/Role/listPager POST', '2023-08-19 16:07:49', '1', '0.0.0.1', 'Role', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-19 16:07:49', 'LogAction', '2023-08-19 16:07:49', 0);
INSERT INTO `sys_log` VALUES ('16458456588829696', 1, '列表', '/User/listPager POST', '2023-08-19 16:07:50', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-19 16:07:50', 'LogAction', '2023-08-19 16:07:50', 0);
INSERT INTO `sys_log` VALUES ('16458457801442304', 1, '列表', '/User/listPager POST', '2023-08-19 16:09:04', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-19 16:09:04', 'LogAction', '2023-08-19 16:09:04', 0);
INSERT INTO `sys_log` VALUES ('16458457817613312', 1, '列表', '/Role/listPager POST', '2023-08-19 16:09:05', '1', '0.0.0.1', 'Role', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-19 16:09:05', 'LogAction', '2023-08-19 16:09:05', 0);
INSERT INTO `sys_log` VALUES ('16458457871713280', 1, '列表', '/CodeDb/listPager POST', '2023-08-19 16:09:08', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-19 16:09:08', 'LogAction', '2023-08-19 16:09:08', 0);
INSERT INTO `sys_log` VALUES ('16459821437240320', 1, '修改', '/Menu/Update POST', '2023-08-20 15:16:14', '1', '0.0.0.1', 'Menu', 'Update', '{\"entity\":{\"Controller\":\"无\",\"Name\":\"dashboard\",\"Title\":\"首页\",\"Path\":\"/\",\"Redirect\":\"/dashboard\",\"Affix\":true,\"Icon\":\"iconfont icon-dashboard\",\"Hidden\":true,\"SortIndex\":1,\"Type\":0,\"ParentId\":\"\",\"Children\":null,\"Actions\":null,\"Id\":\"16235161652659200\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T22:20:29\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T22:32:36\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:16:14', 'LogAction', '2023-08-20 15:16:14', 0);
INSERT INTO `sys_log` VALUES ('16459821852345344', 1, '新增', '/Menu/Insert POST', '2023-08-20 15:16:39', '1', '0.0.0.1', 'Menu', 'Insert', '{\"entity\":{\"Controller\":\"无\",\"Name\":\"1\",\"Title\":\"1\",\"Path\":\"1\",\"Redirect\":\"1\",\"Affix\":false,\"Icon\":\"\",\"Hidden\":true,\"SortIndex\":1,\"Type\":0,\"ParentId\":\"\",\"Children\":null,\"Actions\":null,\"Id\":null,\"Creater\":null,\"CreateTime\":\"0001-01-01T00:00:00\",\"Updater\":null,\"UpTime\":\"0001-01-01T00:00:00\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:16:39', 'LogAction', '2023-08-20 15:16:39', 0);
INSERT INTO `sys_log` VALUES ('16459822010614784', 1, '删除', '/Menu/Delete POST', '2023-08-20 15:16:49', '1', '0.0.0.1', 'Menu', 'Delete', '{\"id\":\"16459821852591104\"}', 'LogAction', '2023-08-20 15:16:49', 'LogAction', '2023-08-20 15:16:49', 0);
INSERT INTO `sys_log` VALUES ('16459822127186944', 1, '列表', '/User/listPager POST', '2023-08-20 15:16:56', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:16:56', 'LogAction', '2023-08-20 15:16:56', 0);
INSERT INTO `sys_log` VALUES ('16459829332214784', 1, '列表', '/User/listPager POST', '2023-08-20 15:24:16', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:24:16', 'LogAction', '2023-08-20 15:24:16', 0);
INSERT INTO `sys_log` VALUES ('16459829547566080', 1, '分配角色', '/User/BindUserRole POST', '2023-08-20 15:24:29', '1', '0.0.0.1', 'User', 'BindUserRole', '{\"userRoleDto\":{\"UserId\":\"1\",\"RoleIds\":[\"1\",\"16235285555201024\"]}}', 'LogAction', '2023-08-20 15:24:29', 'LogAction', '2023-08-20 15:24:29', 0);
INSERT INTO `sys_log` VALUES ('16459829705819136', 1, '分配角色', '/User/BindUserRole POST', '2023-08-20 15:24:38', '1', '0.0.0.1', 'User', 'BindUserRole', '{\"userRoleDto\":{\"UserId\":\"1\",\"RoleIds\":[\"16235285555201024\"]}}', 'LogAction', '2023-08-20 15:24:38', 'LogAction', '2023-08-20 15:24:38', 0);
INSERT INTO `sys_log` VALUES ('16459829852046336', 1, '分配角色', '/User/BindUserRole POST', '2023-08-20 15:24:47', '1', '0.0.0.1', 'User', 'BindUserRole', '{\"userRoleDto\":{\"UserId\":\"1\",\"RoleIds\":[\"16235285555201024\",\"16235285555201024\"]}}', 'LogAction', '2023-08-20 15:24:47', 'LogAction', '2023-08-20 15:24:47', 0);
INSERT INTO `sys_log` VALUES ('16459830447047680', 1, '分配角色', '/User/BindUserRole POST', '2023-08-20 15:25:24', '1', '0.0.0.1', 'User', 'BindUserRole', '{\"userRoleDto\":{\"UserId\":\"1\",\"RoleIds\":[\"1\",\"1\"]}}', 'LogAction', '2023-08-20 15:25:24', 'LogAction', '2023-08-20 15:25:24', 0);
INSERT INTO `sys_log` VALUES ('16459832352670720', 1, '分配角色', '/User/BindUserRole POST', '2023-08-20 15:27:20', '1', '0.0.0.1', 'User', 'BindUserRole', '{\"userRoleDto\":{\"UserId\":\"1\",\"RoleIds\":[\"1\"]}}', 'LogAction', '2023-08-20 15:27:20', 'LogAction', '2023-08-20 15:27:20', 0);
INSERT INTO `sys_log` VALUES ('16459835600831488', 1, '列表', '/User/listPager POST', '2023-08-20 15:30:38', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:30:38', 'LogAction', '2023-08-20 15:30:38', 0);
INSERT INTO `sys_log` VALUES ('16459835885224960', 1, '分配角色', '/User/BindUserRole POST', '2023-08-20 15:30:56', '1', '0.0.0.1', 'User', 'BindUserRole', '{\"userRoleDto\":{\"UserId\":\"1\",\"RoleIds\":[\"16235285555201024\"]}}', 'LogAction', '2023-08-20 15:30:56', 'LogAction', '2023-08-20 15:30:56', 0);
INSERT INTO `sys_log` VALUES ('16459835993097216', 1, '分配角色', '/User/BindUserRole POST', '2023-08-20 15:31:02', '1', '0.0.0.1', 'User', 'BindUserRole', '{\"userRoleDto\":{\"UserId\":\"1\",\"RoleIds\":[\"1\"]}}', 'LogAction', '2023-08-20 15:31:02', 'LogAction', '2023-08-20 15:31:02', 0);
INSERT INTO `sys_log` VALUES ('16459836277294080', 1, '列表', '/User/listPager POST', '2023-08-20 15:31:20', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:31:20', 'LogAction', '2023-08-20 15:31:20', 0);
INSERT INTO `sys_log` VALUES ('16459837421257728', 1, '列表', '/User/listPager POST', '2023-08-20 15:32:29', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:32:29', 'LogAction', '2023-08-20 15:32:29', 0);
INSERT INTO `sys_log` VALUES ('16459837513712640', 1, '分配角色', '/User/BindUserRole POST', '2023-08-20 15:32:35', '1', '0.0.0.1', 'User', 'BindUserRole', '{\"userRoleDto\":{\"UserId\":\"1\",\"RoleIds\":[\"1\",\"16235285555201024\"]}}', 'LogAction', '2023-08-20 15:32:35', 'LogAction', '2023-08-20 15:32:35', 0);
INSERT INTO `sys_log` VALUES ('16459837553574912', 1, '列表', '/User/listPager POST', '2023-08-20 15:32:37', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:32:37', 'LogAction', '2023-08-20 15:32:37', 0);
INSERT INTO `sys_log` VALUES ('16459837646029824', 1, '列表', '/Role/listPager POST', '2023-08-20 15:32:43', '1', '0.0.0.1', 'Role', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:32:43', 'LogAction', '2023-08-20 15:32:43', 0);
INSERT INTO `sys_log` VALUES ('16459837886006272', 1, '新增', '/Role/Insert POST', '2023-08-20 15:32:58', '1', '0.0.0.1', 'Role', 'Insert', '{\"entity\":{\"Name\":\"测试角色\",\"Code\":\"10001\",\"Des\":\"1001\",\"RoleActions\":null,\"UserRoles\":null,\"Id\":null,\"Creater\":null,\"CreateTime\":\"0001-01-01T00:00:00\",\"Updater\":null,\"UpTime\":\"0001-01-01T00:00:00\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:32:58', 'LogAction', '2023-08-20 15:32:58', 0);
INSERT INTO `sys_log` VALUES ('16459837886678016', 1, '列表', '/Role/listPager POST', '2023-08-20 15:32:58', '1', '0.0.0.1', 'Role', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":2,\"Data\":null}}', 'LogAction', '2023-08-20 15:32:58', 'LogAction', '2023-08-20 15:32:58', 0);
INSERT INTO `sys_log` VALUES ('16459838004675584', 1, '修改', '/Role/Update POST', '2023-08-20 15:33:05', '1', '0.0.0.1', 'Role', 'Update', '{\"entity\":{\"Name\":\"测试角色2\",\"Code\":\"100012\",\"Des\":\"10012\",\"RoleActions\":[],\"UserRoles\":null,\"Id\":\"16459837886039040\",\"Creater\":\"1\",\"CreateTime\":\"2023-08-20T15:32:58\",\"Updater\":\"1\",\"UpTime\":\"2023-08-20T15:32:58\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:33:05', 'LogAction', '2023-08-20 15:33:05', 0);
INSERT INTO `sys_log` VALUES ('16459838005134336', 1, '列表', '/Role/listPager POST', '2023-08-20 15:33:05', '1', '0.0.0.1', 'Role', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":3,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:05', 'LogAction', '2023-08-20 15:33:05', 0);
INSERT INTO `sys_log` VALUES ('16459838169973760', 1, '分配权限', '/Role/BindRoleActions POST', '2023-08-20 15:33:15', '1', '0.0.0.1', 'Role', 'BindRoleActions', '{\"roleActionDto\":{\"RoleId\":\"16459837886039040\",\"Actions\":[{\"Controller\":\"dashboard\",\"Action\":\"Display\"},{\"Controller\":\"MenuController\",\"Action\":\"Display\"},{\"Controller\":\"MenuController\",\"Action\":\"Insert\"},{\"Controller\":\"MenuController\",\"Action\":\"Update\"},{\"Controller\":\"MenuController\",\"Action\":\"Delete\"},{\"Controller\":\"MenuController\",\"Action\":\"ListPager\"},{\"Controller\":\"MenuController\",\"Action\":\"InitController\"}],\"UserId\":null}}', 'LogAction', '2023-08-20 15:33:15', 'LogAction', '2023-08-20 15:33:15', 0);
INSERT INTO `sys_log` VALUES ('16459838294737920', 1, '删除', '/Role/Delete POST', '2023-08-20 15:33:23', '1', '0.0.0.1', 'Role', 'Delete', '{\"id\":\"16459837886039040\"}', 'LogAction', '2023-08-20 15:33:23', 'LogAction', '2023-08-20 15:33:23', 0);
INSERT INTO `sys_log` VALUES ('16459838295327744', 1, '列表', '/Role/listPager POST', '2023-08-20 15:33:23', '1', '0.0.0.1', 'Role', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":3,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:23', 'LogAction', '2023-08-20 15:33:23', 0);
INSERT INTO `sys_log` VALUES ('16459838375003136', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:33:28', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:28', 'LogAction', '2023-08-20 15:33:28', 0);
INSERT INTO `sys_log` VALUES ('16459838430938112', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:33:31', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"pagerReq\":{\"Page\":2,\"Size\":10,\"Total\":27,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:31', 'LogAction', '2023-08-20 15:33:31', 0);
INSERT INTO `sys_log` VALUES ('16459838442914816', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:33:32', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"pagerReq\":{\"Page\":3,\"Size\":10,\"Total\":27,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:32', 'LogAction', '2023-08-20 15:33:32', 0);
INSERT INTO `sys_log` VALUES ('16459838465065984', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:33:33', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":27,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:33', 'LogAction', '2023-08-20 15:33:33', 0);
INSERT INTO `sys_log` VALUES ('16459838505239552', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:33:36', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":27,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:36', 'LogAction', '2023-08-20 15:33:36', 0);
INSERT INTO `sys_log` VALUES ('16459838517478400', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:33:36', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":27,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:36', 'LogAction', '2023-08-20 15:33:36', 0);
INSERT INTO `sys_log` VALUES ('16459838520558592', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:33:36', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":27,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:36', 'LogAction', '2023-08-20 15:33:36', 0);
INSERT INTO `sys_log` VALUES ('16459838638081024', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:33:44', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":27,\"Data\":null}}', 'LogAction', '2023-08-20 15:33:44', 'LogAction', '2023-08-20 15:33:44', 0);
INSERT INTO `sys_log` VALUES ('16459851242423296', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:46:33', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"req\":{\"Type\":1,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:46:33', 'LogAction', '2023-08-20 15:46:33', 0);
INSERT INTO `sys_log` VALUES ('16459851273847808', 1, '列表', '/SysLog/listPager POST', '2023-08-20 15:46:35', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"req\":{\"Type\":2,\"Page\":1,\"Size\":10,\"Total\":40,\"Data\":null}}', 'LogAction', '2023-08-20 15:46:35', 'LogAction', '2023-08-20 15:46:35', 0);
INSERT INTO `sys_log` VALUES ('16459851397579776', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:46:42', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:46:42', 'LogAction', '2023-08-20 15:46:42', 0);
INSERT INTO `sys_log` VALUES ('16459851545166848', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:46:51', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:46:51', 'LogAction', '2023-08-20 15:46:51', 0);
INSERT INTO `sys_log` VALUES ('16459851893801984', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:47:13', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:47:13', 'LogAction', '2023-08-20 15:47:13', 0);
INSERT INTO `sys_log` VALUES ('16459854266500096', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:49:38', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:49:38', 'LogAction', '2023-08-20 15:49:38', 0);
INSERT INTO `sys_log` VALUES ('16459854331708416', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:49:42', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:49:42', 'LogAction', '2023-08-20 15:49:42', 0);
INSERT INTO `sys_log` VALUES ('16459857072358400', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:52:29', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:52:29', 'LogAction', '2023-08-20 15:52:29', 0);
INSERT INTO `sys_log` VALUES ('16459857586406400', 1, '新增', '/CodeDb/Insert POST', '2023-08-20 15:53:00', '1', '0.0.0.1', 'CodeDb', 'Insert', '{\"entity\":{\"Name\":\"cms\",\"Type\":\"MySql\",\"ConStr\":\"Server=192.168.110.128;Database=cms;Uid=root;Pwd=mysqlpwd;\",\"UserId\":\"1\",\"Id\":null,\"Creater\":null,\"CreateTime\":\"0001-01-01T00:00:00\",\"Updater\":null,\"UpTime\":\"0001-01-01T00:00:00\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:53:00', 'LogAction', '2023-08-20 15:53:00', 0);
INSERT INTO `sys_log` VALUES ('16459857587291136', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:53:00', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":1,\"Data\":null}}', 'LogAction', '2023-08-20 15:53:00', 'LogAction', '2023-08-20 15:53:00', 0);
INSERT INTO `sys_log` VALUES ('16459858801148928', 1, '修改', '/CodeDb/Update POST', '2023-08-20 15:54:14', '1', '0.0.0.1', 'CodeDb', 'Update', '{\"entity\":{\"Name\":\"cms1\",\"Type\":\"MySql\",\"ConStr\":\"Server=192.168.110.128;Database=cms;Uid=root;Pwd=mysqlpwd;\",\"UserId\":\"1\",\"Id\":\"16459857586439168\",\"Creater\":\"1\",\"CreateTime\":\"2023-08-20T15:53:01\",\"Updater\":\"1\",\"UpTime\":\"2023-08-20T15:53:01\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:54:14', 'LogAction', '2023-08-20 15:54:14', 0);
INSERT INTO `sys_log` VALUES ('16459858801787904', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:54:14', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":2,\"Data\":null}}', 'LogAction', '2023-08-20 15:54:14', 'LogAction', '2023-08-20 15:54:14', 0);
INSERT INTO `sys_log` VALUES ('16459858878317568', 1, '修改', '/CodeDb/Update POST', '2023-08-20 15:54:19', '1', '0.0.0.1', 'CodeDb', 'Update', '{\"entity\":{\"Name\":\"cms\",\"Type\":\"MySql\",\"ConStr\":\"Server=192.168.110.128;Database=cms;Uid=root;Pwd=mysqlpwd;\",\"UserId\":\"1\",\"Id\":\"16459857586439168\",\"Creater\":\"1\",\"CreateTime\":\"2023-08-20T15:53:01\",\"Updater\":\"1\",\"UpTime\":\"2023-08-20T15:54:15\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:54:19', 'LogAction', '2023-08-20 15:54:19', 0);
INSERT INTO `sys_log` VALUES ('16459858878678016', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:54:19', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":2,\"Data\":null}}', 'LogAction', '2023-08-20 15:54:19', 'LogAction', '2023-08-20 15:54:19', 0);
INSERT INTO `sys_log` VALUES ('16459858924864512', 1, '删除', '/CodeDb/Delete POST', '2023-08-20 15:54:22', '1', '0.0.0.1', 'CodeDb', 'Delete', '{\"id\":\"16235190598550528\"}', 'LogAction', '2023-08-20 15:54:22', 'LogAction', '2023-08-20 15:54:22', 0);
INSERT INTO `sys_log` VALUES ('16459858925634560', 1, '列表', '/CodeDb/listPager POST', '2023-08-20 15:54:22', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":2,\"Data\":null}}', 'LogAction', '2023-08-20 15:54:22', 'LogAction', '2023-08-20 15:54:22', 0);
INSERT INTO `sys_log` VALUES ('16459859000706048', 1, '列表', '/CodeTemp/listPager POST', '2023-08-20 15:54:26', '1', '0.0.0.1', 'CodeTemp', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:54:26', 'LogAction', '2023-08-20 15:54:26', 0);
INSERT INTO `sys_log` VALUES ('16459860280935424', 1, '新增', '/CodeTemp/Insert POST', '2023-08-20 15:55:45', '1', '0.0.0.1', 'CodeTemp', 'Insert', '{\"entity\":{\"Name\":\"qqqqq\",\"TempContent\":\"qqqqq\",\"UserId\":\"1\",\"CodeSchemeDetials\":null,\"Id\":null,\"Creater\":null,\"CreateTime\":\"0001-01-01T00:00:00\",\"Updater\":null,\"UpTime\":\"0001-01-01T00:00:00\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:55:45', 'LogAction', '2023-08-20 15:55:45', 0);
INSERT INTO `sys_log` VALUES ('16459860281902080', 1, '列表', '/CodeTemp/listPager POST', '2023-08-20 15:55:45', '1', '0.0.0.1', 'CodeTemp', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:55:45', 'LogAction', '2023-08-20 15:55:45', 0);
INSERT INTO `sys_log` VALUES ('16459860418511872', 1, '列表', '/CodeTemp/listPager POST', '2023-08-20 15:55:53', '1', '0.0.0.1', 'CodeTemp', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:55:53', 'LogAction', '2023-08-20 15:55:53', 0);
INSERT INTO `sys_log` VALUES ('16459862794011648', 1, '列表', '/CodeTemp/listPager POST', '2023-08-20 15:58:18', '1', '0.0.0.1', 'CodeTemp', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:58:18', 'LogAction', '2023-08-20 15:58:18', 0);
INSERT INTO `sys_log` VALUES ('16459862900573184', 1, '修改', '/CodeTemp/Update POST', '2023-08-20 15:58:25', '1', '0.0.0.1', 'CodeTemp', 'Update', '{\"entity\":{\"Name\":\"qqqqq\",\"TempContent\":\"qqqqq111\",\"UserId\":\"1\",\"CodeSchemeDetials\":null,\"Id\":\"16459860280968193\",\"Creater\":\"1\",\"CreateTime\":\"2023-08-20T15:55:45\",\"Updater\":\"1\",\"UpTime\":\"2023-08-20T15:55:45\",\"IsDel\":0}}', 'LogAction', '2023-08-20 15:58:25', 'LogAction', '2023-08-20 15:58:25', 0);
INSERT INTO `sys_log` VALUES ('16459862903817216', 1, '列表', '/CodeTemp/listPager POST', '2023-08-20 15:58:25', '1', '0.0.0.1', 'CodeTemp', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":10,\"Data\":null}}', 'LogAction', '2023-08-20 15:58:25', 'LogAction', '2023-08-20 15:58:25', 0);
INSERT INTO `sys_log` VALUES ('16459862978659328', 1, '删除', '/CodeTemp/Delete POST', '2023-08-20 15:58:29', '1', '0.0.0.1', 'CodeTemp', 'Delete', '{\"id\":\"16459860280968193\"}', 'LogAction', '2023-08-20 15:58:29', 'LogAction', '2023-08-20 15:58:29', 0);
INSERT INTO `sys_log` VALUES ('16459862979445760', 1, '列表', '/CodeTemp/listPager POST', '2023-08-20 15:58:29', '1', '0.0.0.1', 'CodeTemp', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":10,\"Data\":null}}', 'LogAction', '2023-08-20 15:58:29', 'LogAction', '2023-08-20 15:58:29', 0);
INSERT INTO `sys_log` VALUES ('16459863174841344', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 15:58:41', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 15:58:41', 'LogAction', '2023-08-20 15:58:41', 0);
INSERT INTO `sys_log` VALUES ('16459869796779008', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:05:25', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 16:05:25', 'LogAction', '2023-08-20 16:05:25', 0);
INSERT INTO `sys_log` VALUES ('16459881583477760', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:17:25', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 16:17:25', 'LogAction', '2023-08-20 16:17:25', 0);
INSERT INTO `sys_log` VALUES ('16459881674130432', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:17:30', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 16:17:30', 'LogAction', '2023-08-20 16:17:30', 0);
INSERT INTO `sys_log` VALUES ('16459883122967552', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:18:59', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 16:18:59', 'LogAction', '2023-08-20 16:18:59', 0);
INSERT INTO `sys_log` VALUES ('16459886361609216', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:22:16', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 16:22:16', 'LogAction', '2023-08-20 16:22:16', 0);
INSERT INTO `sys_log` VALUES ('16459887100249088', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:23:02', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-20 16:23:02', 'LogAction', '2023-08-20 16:23:02', 0);
INSERT INTO `sys_log` VALUES ('16459887685796864', 1, '新增', '/CodeGenScheme/Insert POST', '2023-08-20 16:23:37', '1', '0.0.0.1', 'CodeGenScheme', 'Insert', '{\"entity\":{\"CodeGenScheme\":{\"Name\":\"framework后台模板生成方案\",\"Des\":\"framework后台模板生成方案\",\"UserId\":\"1\",\"CodeSchemeDetials\":[{\"FileName\":\"Jt.SingleService.Core/Tables/{ClassName}.cs\",\"TempId\":\"16235191720985600\",\"GenSchemeId\":\"16235209982116864\",\"CodeTemp\":{\"Name\":\"Jt.SingleService.Core.Tables模板\",\"TempContent\":\"using System.ComponentModel.DataAnnotations.Schema;\\n\\nnamespace Jt.SingleService.Core.Tables\\n{\\n   [Table(\\\"@(Model.TableName)\\\")]\\n    public class @(Model.ClassName) : BaseEntity\\n    {\\n        @for(int i = 0; i < Model.DbFieldInfos.Count;i++ )\\n        {\\n        \\t@:[Column(\\\"@(Model.DbFieldInfos[i].FieldName)\\\")]\\n        \\t@:public @(Model.DbFieldInfos[i].FieldModelType) @(Model.DbFieldInfos[i].FieldModelName) { get; set; }\\n\\n        }\\n    }\\n}\",\"UserId\":\"1\",\"CodeSchemeDetials\":[],\"Id\":\"16235191720985600\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T22:51:04\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T22:51:04\",\"IsDel\":0},\"CodeGenScheme\":null,\"Id\":\"16235209982166016\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T23:09:39\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T23:09:39\",\"IsDel\":0},{\"FileName\":\"Jt.SingleService.Core/Tables/Mappers/{ClassName}Mapper.cs\",\"TempId\":\"16235191915955200\",\"GenSchemeId\":\"16235209982116864\",\"CodeTemp\":{\"Name\":\"Jt.SingleService.Core.Tables.Mappers模板\",\"TempContent\":\"using Jt.SingleService.Core.Tables;\\nusing Microsoft.EntityFrameworkCore;\\nusing Microsoft.EntityFrameworkCore.Metadata.Builders;\\n\\nnamespace Jt.SingleService.Core.Tables.Mappers\\n{\\n    public class @(Model.ClassName)Mapper : IEntityTypeConfiguration<@(Model.ClassName)>\\n    {\\n        public void Configure(EntityTypeBuilder<@(Model.ClassName)> builder)\\n        {\\n            builder.HasKey(m => m.Id);\\n        }\\n    }\\n}\",\"UserId\":\"1\",\"CodeSchemeDetials\":[],\"Id\":\"16235191915955200\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T22:51:16\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T22:51:16\",\"IsDel\":0},\"CodeGenScheme\":null,\"Id\":\"16235209982166017\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T23:09:39\",\"Updater\":\"1\",\"Up', 'LogAction', '2023-08-20 16:23:37', 'LogAction', '2023-08-20 16:23:37', 0);
INSERT INTO `sys_log` VALUES ('16459887688041472', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:23:37', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":2,\"Data\":null}}', 'LogAction', '2023-08-20 16:23:37', 'LogAction', '2023-08-20 16:23:37', 0);
INSERT INTO `sys_log` VALUES ('16459887930180608', 1, '新增', '/CodeGenScheme/Insert POST', '2023-08-20 16:23:52', '1', '0.0.0.1', 'CodeGenScheme', 'Insert', '{\"entity\":{\"CodeGenScheme\":{\"Name\":\"framework后台模板生成方案\",\"Des\":\"framework后台模板生成方案\",\"UserId\":\"1\",\"CodeSchemeDetials\":[{\"FileName\":\"Jt.SingleService.Core/Tables/{ClassName}.cs\",\"TempId\":\"16235191720985600\",\"GenSchemeId\":\"16235209982116864\",\"CodeTemp\":{\"Name\":\"Jt.SingleService.Core.Tables模板\",\"TempContent\":\"using System.ComponentModel.DataAnnotations.Schema;\\n\\nnamespace Jt.SingleService.Core.Tables\\n{\\n   [Table(\\\"@(Model.TableName)\\\")]\\n    public class @(Model.ClassName) : BaseEntity\\n    {\\n        @for(int i = 0; i < Model.DbFieldInfos.Count;i++ )\\n        {\\n        \\t@:[Column(\\\"@(Model.DbFieldInfos[i].FieldName)\\\")]\\n        \\t@:public @(Model.DbFieldInfos[i].FieldModelType) @(Model.DbFieldInfos[i].FieldModelName) { get; set; }\\n\\n        }\\n    }\\n}\",\"UserId\":\"1\",\"CodeSchemeDetials\":[],\"Id\":\"16235191720985600\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T22:51:04\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T22:51:04\",\"IsDel\":0},\"CodeGenScheme\":null,\"Id\":\"16235209982166016\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T23:09:39\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T23:09:39\",\"IsDel\":1},{\"FileName\":\"Jt.SingleService.Core/Tables/Mappers/{ClassName}Mapper.cs\",\"TempId\":\"16235191915955200\",\"GenSchemeId\":\"16235209982116864\",\"CodeTemp\":{\"Name\":\"Jt.SingleService.Core.Tables.Mappers模板\",\"TempContent\":\"using Jt.SingleService.Core.Tables;\\nusing Microsoft.EntityFrameworkCore;\\nusing Microsoft.EntityFrameworkCore.Metadata.Builders;\\n\\nnamespace Jt.SingleService.Core.Tables.Mappers\\n{\\n    public class @(Model.ClassName)Mapper : IEntityTypeConfiguration<@(Model.ClassName)>\\n    {\\n        public void Configure(EntityTypeBuilder<@(Model.ClassName)> builder)\\n        {\\n            builder.HasKey(m => m.Id);\\n        }\\n    }\\n}\",\"UserId\":\"1\",\"CodeSchemeDetials\":[],\"Id\":\"16235191915955200\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T22:51:16\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T22:51:16\",\"IsDel\":0},\"CodeGenScheme\":null,\"Id\":\"16235209982166017\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T23:09:39\",\"Updater\":\"1\",\"Up', 'LogAction', '2023-08-20 16:23:52', 'LogAction', '2023-08-20 16:23:52', 0);
INSERT INTO `sys_log` VALUES ('16459887931130880', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:23:52', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":2,\"Data\":null}}', 'LogAction', '2023-08-20 16:23:52', 'LogAction', '2023-08-20 16:23:52', 0);
INSERT INTO `sys_log` VALUES ('16459890181555200', 1, '新增', '/CodeGenScheme/Insert POST', '2023-08-20 16:26:10', '1', '0.0.0.1', 'CodeGenScheme', 'Insert', '{\"entity\":{\"CodeGenScheme\":{\"Name\":\"framework后台模板生成方案\",\"Des\":\"framework后台模板生成方案\",\"UserId\":\"1\",\"CodeSchemeDetials\":[{\"FileName\":\"Jt.SingleService.Core/Tables/Mappers/{ClassName}Mapper.cs\",\"TempId\":\"16235191915955200\",\"GenSchemeId\":\"16235209982116864\",\"CodeTemp\":{\"Name\":\"Jt.SingleService.Core.Tables.Mappers模板\",\"TempContent\":\"using Jt.SingleService.Core.Tables;\\nusing Microsoft.EntityFrameworkCore;\\nusing Microsoft.EntityFrameworkCore.Metadata.Builders;\\n\\nnamespace Jt.SingleService.Core.Tables.Mappers\\n{\\n    public class @(Model.ClassName)Mapper : IEntityTypeConfiguration<@(Model.ClassName)>\\n    {\\n        public void Configure(EntityTypeBuilder<@(Model.ClassName)> builder)\\n        {\\n            builder.HasKey(m => m.Id);\\n        }\\n    }\\n}\",\"UserId\":\"1\",\"CodeSchemeDetials\":[],\"Id\":\"16235191915955200\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T22:51:16\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T22:51:16\",\"IsDel\":0},\"CodeGenScheme\":null,\"Id\":\"16459887930721280\",\"Creater\":\"1\",\"CreateTime\":\"2023-08-20T16:23:53\",\"Updater\":\"1\",\"UpTime\":\"2023-08-20T16:23:53\",\"IsDel\":0},{\"FileName\":\"Jt.SingleService.Core/Repositories/I{ClassName}Repo.cs\",\"TempId\":\"16235192159683584\",\"GenSchemeId\":\"16235209982116864\",\"CodeTemp\":{\"Name\":\"Jt.SingleService.Core.Repositories模板\",\"TempContent\":\"using Jt.SingleService.Core.Tables;\\nusing Jt.SingleService.Core.Repositories;\\n\\nnamespace Jt.SingleService.Core.Repositories\\n{\\n    public interface I@(Model.ClassName)Repo : IBaseRepo<@(Model.ClassName)>\\n    {\\n\\n    }\\n}\",\"UserId\":\"1\",\"CodeSchemeDetials\":[],\"Id\":\"16235192159683584\",\"Creater\":\"1\",\"CreateTime\":\"2023-03-14T22:51:31\",\"Updater\":\"1\",\"UpTime\":\"2023-03-14T22:51:31\",\"IsDel\":0},\"CodeGenScheme\":null,\"Id\":\"16459887930721281\",\"Creater\":\"1\",\"CreateTime\":\"2023-08-20T16:23:53\",\"Updater\":\"1\",\"UpTime\":\"2023-08-20T16:23:53\",\"IsDel\":0},{\"FileName\":\"Jt.SingleService.Data/Repositories/{ClassName}Repo.cs\",\"TempId\":\"16235192300913664\",\"GenSchemeId\":\"16235209982116864\",\"CodeTemp\":{\"Name\":\"Jt.SingleService.Data.Repo', 'LogAction', '2023-08-20 16:26:10', 'LogAction', '2023-08-20 16:26:10', 0);
INSERT INTO `sys_log` VALUES ('16459890187011072', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-20 16:26:10', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":2,\"Data\":null}}', 'LogAction', '2023-08-20 16:26:10', 'LogAction', '2023-08-20 16:26:10', 0);
INSERT INTO `sys_log` VALUES ('16459890352702464', 1, '连接', '/CodeGenerator/SetDb POST', '2023-08-20 16:26:20', '1', '0.0.0.1', 'CodeGenerator', 'SetDb', '{\"dbType\":\"MySql\",\"connectString\":\"Server=192.168.110.128;Database=cms;Uid=root;Pwd=mysqlpwd;\"}', 'LogAction', '2023-08-20 16:26:20', 'LogAction', '2023-08-20 16:26:20', 0);
INSERT INTO `sys_log` VALUES ('16459893003650048', 1, '连接', '/CodeGenerator/SetDb POST', '2023-08-20 16:29:02', '1', '0.0.0.1', 'CodeGenerator', 'SetDb', '{\"dbType\":\"MySql\",\"connectString\":\"Server=192.168.110.128;Database=cms;Uid=root;Pwd=mysqlpwd;\"}', 'LogAction', '2023-08-20 16:29:02', 'LogAction', '2023-08-20 16:29:02', 0);
INSERT INTO `sys_log` VALUES ('16459893218690048', 1, '生成', '/CodeGenerator/CodeGenerator POST', '2023-08-20 16:29:15', '1', '0.0.0.1', 'CodeGenerator', 'CodeGenerator', '{\"codeTempParams\":{\"CodeSchemeId\":\"16235209982116864\",\"TableName\":\"action\",\"ClassName\":\"Action\",\"DbFieldInfos\":[{\"FieldName\":\"id\",\"FieldModelName\":\"Id\",\"FieldModelNameCamel\":\"id\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"id\",\"DefaultValue\":null},{\"FieldName\":\"controller\",\"FieldModelName\":\"Controller\",\"FieldModelNameCamel\":\"controller\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"控制器\",\"DefaultValue\":\"\"},{\"FieldName\":\"name\",\"FieldModelName\":\"Name\",\"FieldModelNameCamel\":\"name\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"action\",\"DefaultValue\":\"\"},{\"FieldName\":\"text\",\"FieldModelName\":\"Text\",\"FieldModelNameCamel\":\"text\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"文本\",\"DefaultValue\":\"\"},{\"FieldName\":\"creater\",\"FieldModelName\":\"Creater\",\"FieldModelNameCamel\":\"creater\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"添加人\",\"DefaultValue\":\"\"},{\"FieldName\":\"create_time\",\"FieldModelName\":\"CreateTime\",\"FieldModelNameCamel\":\"createTime\",\"FieldDbType\":\"datetime\",\"FieldModelType\":\"DateTime\",\"FieldLength\":0,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"添加时间\",\"DefaultValue\":\"CURRENT_TIMESTAMP\"},{\"FieldName\":\"updater\",\"FieldModelName\":\"Updater\",\"FieldModelNameCamel\":\"updater\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"最后修改人\",\"DefaultValue', 'LogAction', '2023-08-20 16:29:15', 'LogAction', '2023-08-20 16:29:15', 0);
INSERT INTO `sys_log` VALUES ('16461659208680448', 1, '列表', '/User/listPager POST', '2023-08-21 22:25:42', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:25:42', 'LogAction', '2023-08-21 22:25:42', 0);
INSERT INTO `sys_log` VALUES ('16461659213595648', 2, '/User/listPager POST', 'Table \'single.user_follow\' doesn\'t exist', '2023-08-21 22:25:43', '1', '0.0.0.1', 'User', 'ListPager', 'pagerReq,Jt.SingleService.Data.GetPagerListReq;', 'LogAction', '2023-08-21 22:25:43', 'LogAction', '2023-08-21 22:25:43', 0);
INSERT INTO `sys_log` VALUES ('16461663125996544', 1, '列表', '/User/listPager POST', '2023-08-21 22:29:42', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:29:42', 'LogAction', '2023-08-21 22:29:42', 0);
INSERT INTO `sys_log` VALUES ('16461663130698752', 2, '/User/listPager POST', 'Table \'single.user_follow\' doesn\'t exist', '2023-08-21 22:29:42', '1', '0.0.0.1', 'User', 'ListPager', 'pagerReq,Jt.SingleService.Data.GetPagerListReq;', 'LogAction', '2023-08-21 22:29:42', 'LogAction', '2023-08-21 22:29:42', 0);
INSERT INTO `sys_log` VALUES ('16461665273447424', 1, '列表', '/User/listPager POST', '2023-08-21 22:31:53', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:31:53', 'LogAction', '2023-08-21 22:31:53', 0);
INSERT INTO `sys_log` VALUES ('16461665776190464', 1, '列表', '/User/listPager POST', '2023-08-21 22:32:23', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:32:23', 'LogAction', '2023-08-21 22:32:23', 0);
INSERT INTO `sys_log` VALUES ('16461666867397632', 1, '列表', '/User/listPager POST', '2023-08-21 22:33:30', '1', '0.0.0.1', 'User', 'ListPager', '{\"pagerReq\":{\"UserName\":null,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:33:30', 'LogAction', '2023-08-21 22:33:30', 0);
INSERT INTO `sys_log` VALUES ('16461666975613952', 1, '列表', '/Role/listPager POST', '2023-08-21 22:33:37', '1', '0.0.0.1', 'Role', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:33:37', 'LogAction', '2023-08-21 22:33:37', 0);
INSERT INTO `sys_log` VALUES ('16461667119498240', 1, '列表', '/SysLog/listPager POST', '2023-08-21 22:33:45', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"req\":{\"Type\":1,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:33:45', 'LogAction', '2023-08-21 22:33:45', 0);
INSERT INTO `sys_log` VALUES ('16461667142829056', 1, '列表', '/SysLog/listPager POST', '2023-08-21 22:33:47', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"req\":{\"Type\":2,\"Page\":1,\"Size\":10,\"Total\":85,\"Data\":null}}', 'LogAction', '2023-08-21 22:33:47', 'LogAction', '2023-08-21 22:33:47', 0);
INSERT INTO `sys_log` VALUES ('16461667497493504', 1, '列表', '/SysLog/listPager POST', '2023-08-21 22:34:08', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"req\":{\"Type\":1,\"Page\":1,\"Size\":10,\"Total\":2,\"Data\":null}}', 'LogAction', '2023-08-21 22:34:08', 'LogAction', '2023-08-21 22:34:08', 0);
INSERT INTO `sys_log` VALUES ('16461667565159424', 1, '列表', '/CodeDb/listPager POST', '2023-08-21 22:34:12', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:34:12', 'LogAction', '2023-08-21 22:34:12', 0);
INSERT INTO `sys_log` VALUES ('16461667649029120', 1, '修改', '/CodeDb/Update POST', '2023-08-21 22:34:18', '1', '0.0.0.1', 'CodeDb', 'Update', '{\"entity\":{\"Name\":\"cms\",\"Type\":\"MySql\",\"ConStr\":\"Server=192.168.110.128;Database=cms;Uid=root;Pwd=mysqlpwd;\",\"UserId\":\"1\",\"Id\":\"16459857586439168\",\"Creater\":\"1\",\"CreateTime\":\"2023-08-20T15:53:01\",\"Updater\":\"1\",\"UpTime\":\"2023-08-20T15:54:20\",\"IsDel\":0}}', 'LogAction', '2023-08-21 22:34:18', 'LogAction', '2023-08-21 22:34:18', 0);
INSERT INTO `sys_log` VALUES ('16461667649831936', 1, '列表', '/CodeDb/listPager POST', '2023-08-21 22:34:18', '1', '0.0.0.1', 'CodeDb', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":1,\"Data\":null}}', 'LogAction', '2023-08-21 22:34:18', 'LogAction', '2023-08-21 22:34:18', 0);
INSERT INTO `sys_log` VALUES ('16461667693888512', 1, '列表', '/CodeTemp/listPager POST', '2023-08-21 22:34:20', '1', '0.0.0.1', 'CodeTemp', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:34:20', 'LogAction', '2023-08-21 22:34:20', 0);
INSERT INTO `sys_log` VALUES ('16461667726672896', 1, '列表', '/CodeGenScheme/listPager POST', '2023-08-21 22:34:22', '1', '0.0.0.1', 'CodeGenScheme', 'ListPager', '{\"pagerReq\":{\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:34:22', 'LogAction', '2023-08-21 22:34:22', 0);
INSERT INTO `sys_log` VALUES ('16461667776103424', 1, '连接', '/CodeGenerator/SetDb POST', '2023-08-21 22:34:25', '1', '0.0.0.1', 'CodeGenerator', 'SetDb', '{\"dbType\":\"MySql\",\"connectString\":\"Server=192.168.110.128;Database=cms;Uid=root;Pwd=mysqlpwd;\"}', 'LogAction', '2023-08-21 22:34:25', 'LogAction', '2023-08-21 22:34:25', 0);
INSERT INTO `sys_log` VALUES ('16461667884581888', 1, '生成', '/CodeGenerator/CodeGenerator POST', '2023-08-21 22:34:32', '1', '0.0.0.1', 'CodeGenerator', 'CodeGenerator', '{\"codeTempParams\":{\"CodeSchemeId\":\"16235207007994880\",\"TableName\":\"action\",\"ClassName\":\"Action\",\"DbFieldInfos\":[{\"FieldName\":\"id\",\"FieldModelName\":\"Id\",\"FieldModelNameCamel\":\"id\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"id\",\"DefaultValue\":null},{\"FieldName\":\"controller\",\"FieldModelName\":\"Controller\",\"FieldModelNameCamel\":\"controller\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"控制器\",\"DefaultValue\":\"\"},{\"FieldName\":\"name\",\"FieldModelName\":\"Name\",\"FieldModelNameCamel\":\"name\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"action\",\"DefaultValue\":\"\"},{\"FieldName\":\"text\",\"FieldModelName\":\"Text\",\"FieldModelNameCamel\":\"text\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"文本\",\"DefaultValue\":\"\"},{\"FieldName\":\"creater\",\"FieldModelName\":\"Creater\",\"FieldModelNameCamel\":\"creater\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"添加人\",\"DefaultValue\":\"\"},{\"FieldName\":\"create_time\",\"FieldModelName\":\"CreateTime\",\"FieldModelNameCamel\":\"createTime\",\"FieldDbType\":\"datetime\",\"FieldModelType\":\"DateTime\",\"FieldLength\":0,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"添加时间\",\"DefaultValue\":\"CURRENT_TIMESTAMP\"},{\"FieldName\":\"updater\",\"FieldModelName\":\"Updater\",\"FieldModelNameCamel\":\"updater\",\"FieldDbType\":\"varchar\",\"FieldModelType\":\"string\",\"FieldLength\":50,\"NumberLength\":0,\"DecimalPoint\":0,\"IsNotNull\":\"NO\",\"IsIncrement\":0,\"IsPrimaryKey\":0,\"FieldDes\":\"最后修改人\",\"DefaultValue', 'LogAction', '2023-08-21 22:34:32', 'LogAction', '2023-08-21 22:34:32', 0);
INSERT INTO `sys_log` VALUES ('16461680543777792', 1, '列表', '/SysLog/listPager POST', '2023-08-21 22:47:25', '1', '0.0.0.1', 'SysLog', 'ListPager', '{\"req\":{\"Type\":1,\"Page\":1,\"Size\":10,\"Total\":0,\"Data\":null}}', 'LogAction', '2023-08-21 22:47:25', 'LogAction', '2023-08-21 22:47:25', 0);

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `user_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '用户名',
  `password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '密码',
  `register_time` datetime(0) NOT NULL COMMENT '注册时间',
  `login_time` datetime(0) NOT NULL COMMENT '登录时间',
  `status` int(11) NOT NULL DEFAULT 0 COMMENT '状态',
  `avatar` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '头像',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1', 'admin', 'C3A10AC39C3949C2BA59C2ABC2BE56C3A057C3B20FC2883E', '2023-03-13 19:51:29', '2023-08-19 16:05:58', 0, 'Files\\Avatars\\5e09a9_Joont.jpg', '超级管理员', '2023-03-13 11:54:40', '超级管理员', '2023-08-19 16:05:58', 0);

-- ----------------------------
-- Table structure for user_role
-- ----------------------------
DROP TABLE IF EXISTS `user_role`;
CREATE TABLE `user_role`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'id',
  `role_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '角色id',
  `user_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0' COMMENT '用户id',
  `creater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '添加人',
  `create_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `updater` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '最后修改人',
  `up_time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `is_del` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user_role
-- ----------------------------
INSERT INTO `user_role` VALUES ('1', '1', '1', '超级管理员', '2023-03-13 11:54:56', '超级管理员', '2023-03-13 11:54:56', 1);
INSERT INTO `user_role` VALUES ('16236469000668160', '16235285555201024', '16235302472401920', '', '2023-03-15 20:30:23', '', '2023-03-15 20:30:23', 0);
INSERT INTO `user_role` VALUES ('16236469000668161', '1', '16235302472401920', '', '2023-03-15 20:30:23', '', '2023-03-15 20:30:23', 0);
INSERT INTO `user_role` VALUES ('16459829547942912', '1', '1', '', '2023-08-20 15:24:29', '', '2023-08-20 15:24:29', 1);
INSERT INTO `user_role` VALUES ('16459829547942913', '16235285555201024', '1', '', '2023-08-20 15:24:29', '', '2023-08-20 15:24:29', 1);
INSERT INTO `user_role` VALUES ('16459829705950208', '16235285555201024', '1', '', '2023-08-20 15:24:39', '', '2023-08-20 15:24:39', 1);
INSERT INTO `user_role` VALUES ('16459829852275712', '16235285555201024', '1', '', '2023-08-20 15:24:48', '', '2023-08-20 15:24:48', 1);
INSERT INTO `user_role` VALUES ('16459829852275713', '16235285555201024', '1', '', '2023-08-20 15:24:48', '', '2023-08-20 15:24:48', 1);
INSERT INTO `user_role` VALUES ('16459830447162368', '1', '1', '', '2023-08-20 15:25:24', '', '2023-08-20 15:25:24', 1);
INSERT INTO `user_role` VALUES ('16459830447162369', '1', '1', '', '2023-08-20 15:25:24', '', '2023-08-20 15:25:24', 1);
INSERT INTO `user_role` VALUES ('16459832352752640', '1', '1', '', '2023-08-20 15:27:21', '', '2023-08-20 15:27:21', 1);
INSERT INTO `user_role` VALUES ('16459835886306304', '16235285555201024', '1', '', '2023-08-20 15:30:56', '', '2023-08-20 15:30:56', 1);
INSERT INTO `user_role` VALUES ('16459835993211904', '1', '1', '', '2023-08-20 15:31:03', '', '2023-08-20 15:31:03', 1);
INSERT INTO `user_role` VALUES ('16459837515154432', '1', '1', '', '2023-08-20 15:32:36', '', '2023-08-20 15:32:36', 0);
INSERT INTO `user_role` VALUES ('16459837515154433', '16235285555201024', '1', '', '2023-08-20 15:32:36', '', '2023-08-20 15:32:36', 0);

SET FOREIGN_KEY_CHECKS = 1;
